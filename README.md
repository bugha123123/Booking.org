

[BookingWebsiteDescription(C4).pptx](https://github.com/user-attachments/files/17578265/BookingWebsiteDescription.C4.pptx)



Email Notifications:

The application uses SMTP to send email notifications for various events such as booking confirmations and password resets. The email content is formatted using HTML for better presentation.

Technologies Used:
    ASP.NET Core MVC
    Entity Framework Core for database operations
    Identity for user authentication and authorization
    SMTP for sending emails

 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Functionalities:

User Account Management
    Register: Users can register an account by providing necessary details.
    Login/Logout: Users can log in and log out of their accounts.
    Profile Management: Users can update their profiles, including uploading a profile image and updating card details.
    Password Reset: Users can reset their passwords by providing their email and a reset token.

Hotel Booking
    Book Hotel: Users can book a hotel by providing hotel ID and payment details. The service validates payment details and sends an email receipt upon successful booking.
    View Bookings: Users can view their booked hotels.
    Cancel Booking: Users can cancel their bookings, which updates their points and tier levels accordingly.

Hotel Management
    Search Hotels: Users can search for hotels based on various criteria such as place, check-in/out times, number of adults/children, etc.
    Filter Hotels: Users can filter hotels by price, amenities, rating, and number of rooms.
    Favorite Hotels: Users can add hotels to their favorites and manage their list of favorite hotels.
    View Expensive Hotels: Users can view a list of expensive hotels.

Reviews
    Add Reviews: Users can add reviews for hotels they have booked.
    View Reviews: Users can view reviews for a specific hotel.

    
 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 
Key Components

  Controllers
        AccountController: Manages user account functionalities such as registration, login, logout, password reset, and profile updates.
        HotelController: Handles hotel-related operations such as booking, viewing, searching, and managing favorites.

  Services
        HotelService: Provides business logic for hotel operations including booking hotels, validating payment details, managing bookings, and sending email notifications.
        AccountService: Handles user account operations like registration, login, updating profiles, and managing user-related data.

   Models
        User: Represents a user in the system, extending IdentityUser to include properties for card details, profile image, role, tier levels, and points.
        Hotels, BookedHotels, Favourites, Flights, Reviews: Represents various entities related to hotels, bookings, favorite hotels, flights, and reviews.
        (same goes for every model)

  DTO (Data Transfer Objects)
        RegisterViewModel, LoginViewModel: Used to transfer data for user registration and login operations.


