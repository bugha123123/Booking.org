﻿using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;
using static Hotel.org.Models.Hotels;

namespace Hotel.org.Service
{
    public class HotelService : IHotelService
    {

        private readonly AppDbContext _appDbContext;
        private readonly IAccountService _accountService;
        public HotelService(AppDbContext appDbContext, IAccountService accountService)
        {
            _appDbContext = appDbContext;
            _accountService = accountService;
        }


        //books hotel for user
        public async Task BookHotel(int hotelId)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var foundHotel = await GetHotelById(hotelId);

            // Check if the user has already booked this hotel
            var existingBooking = await _appDbContext.bookedHotels
                .FirstOrDefaultAsync(b => b.AddedBy == user.UserName && b.HotelId == foundHotel.Id);

            // If the user has already booked this hotel, return without booking again
            if (existingBooking != null)
            {
                // You can handle this case as needed, such as throwing an exception or logging a message
                return;
            }

            // Create a new booked hotel entry
            var bookedHotel = new BookedHotels()
            {
                AddedBy = user.UserName,
                HotelId = foundHotel.Id,
                hotel = foundHotel,
                BookedHotelImage = foundHotel.RoomImage,
            };

            await _appDbContext.bookedHotels.AddAsync(bookedHotel);
            await _appDbContext.SaveChangesAsync();
        }


        public Task<Hotels> GetHotelById(int id)
        {
            var hotel = _appDbContext.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            return hotel;
        }
        public async Task<bool> IsHotelBookedAsync(int hotelId)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var foundHotel = await GetHotelById(hotelId);
            if (user == null)
            {
                return false; // User not logged in, so the hotel is not booked
            }

            return await _appDbContext.bookedHotels.AnyAsync(b => b.AddedBy == user.UserName && b.HotelId == foundHotel.Id);
        }


        //takes 8 hotels and returns them 
        public async Task<List<Hotels>> GetHotelsAsync()
        {
        return    await _appDbContext.Hotels.Take(8).ToListAsync(); 
        }

        //searches for hotel using query
        public async Task<List<Hotels>> SearchForHotel(string? place, string? checkInDate, string? checkOutDate, string? AdultsCount, string? ChildrenCount)
        {
            var query = _appDbContext.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(place))
            {
                query = query.Where(hotel => hotel.City.ToLower().Contains(place.ToLower()));
            }

         

            if (!string.IsNullOrEmpty(AdultsCount) && Enum.TryParse<NumberOfAdultsEnum>(AdultsCount, out var adults))
            {
                query = query.Where(hotel => hotel.NumberOfAdults == adults);
            }

            if (!string.IsNullOrEmpty(ChildrenCount) && Enum.TryParse<NumberOfChildrenEnum>(ChildrenCount, out var children))
            {
                query = query.Where(hotel => hotel.NumberOfChildren == children);
            }

            // Execute the query and return the filtered hotels
            return await query.ToListAsync();
        }


        //gets booked hotels by id and checks if that booked hotel is for logged in  user or not
        public async Task<BookedHotels> GetBookedHotelById(int hotelId)
        {
            // Retrieve the logged-in user
            var user = await _accountService.GetLoggedInUserAsync();
            var foundHotel = await GetHotelById(hotelId);
            // If user is null, handle the case appropriately (e.g., return null or throw an exception)
            if (user == null)
            {
                throw new InvalidOperationException("Unable to retrieve logged in user.");
            }

            // Query the database for the booked hotel matching the hotelId and added by the logged-in user
            var foundBookedHotel = await _appDbContext.bookedHotels.FirstOrDefaultAsync(bh => bh.HotelId == foundHotel.Id && bh.AddedBy == user.Email);

            // If no booked hotel is found, return null
            if (foundBookedHotel == null)
            {
                return null;
            }

            // Return the found booked hotel
            return foundBookedHotel;
        }

    }
}
