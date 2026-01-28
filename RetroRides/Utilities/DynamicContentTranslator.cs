using System;

namespace RetroRides.Utilities
{
    public static class DynamicContentTranslator
    {
        public static class EntitiesTranslation
        {
            public static string Username => "Username";
            public static string UsernameExists => "Such username exists!";

            public static string Password => "Password";
            public static string ProfilePicture => "Picture is required";
            public static string ProfileRegistered => "Profile registered successfully!";
            public static string ProfileUpdatedSuccessfully => "Profile updated successfully!";
            public static string ProfileUpdateFailed => "Failed to update profile! Please try again!";
            public static string ProfileDeleteWarning => "Are you sure you want to delete your account? This action cannot be undone!";
            public static string ProfileDeletionSuccessful => "Your account has been deleted successfully!";
            public static string ProfileDeletionFailed => "Failed to delete the account! Please try again!";

            public static string EmptyInputData => "Please fill in all input fields!";
            public static string EmptyOrInvalidImage => "An error occured while processing your image!";
            public static string InvalidUserCredentials => "Invalid username or password!";
            public static string RoomIsAlreadyReservated => "The selected room is already reserved for the chosen dates!";
            public static string RoomIsUnavailable => "The selected room is currently inavailable!";
            public static string RoomNumberExists => "Such room number already exists";
            public static string InvalidCheckOutDate => "Check-out date must be later than check-in date!";
            public static string EmptyReviewMessage => "Please write a review before submitting!";

            public static string ReadMore => "Read more";
            public static string ItemName => "Name:";
            public static string ItemDescription => "Description:";
            public static string WriteReviewPlaceholder => "Write your review here...";
            public static string WritenOn => "On:";
            public static string WritenAt => "At:";
            public static string Update => "Edit";
            public static string SendReview => "Send";

            public static string Reserve => "Reserve";
            public static string ReservedBy => "Reserved by:";
            public static string Cancel => "Cancel";

            public static string Edit => "Edit";
            public static string Delete => "Delete";
            public static string AvailableMessage => "Available";
            public static string UnavailableMessage => "Unavailable";

            public static string IsAvailableAnswer => "Yes";
            public static string IsNotAvailableAnswer => "No";

            public static string RoomNumber => "Room:";
            public static string DaysReserved => "Days Reserved:";
            public static string Price => "Total price:";
            public static string CheckIn => "Check in:";
            public static string CheckOut => "Check out:";
            public static string Confirmation => "Confirmation";
            public static string ConfirmationMessage => "Are you sure you want to cancel your reservation?";

            public static string RoomType => "Type:";
            public static string Error => "Error";
            public static string Success => "Success";
            public static string DeletionSuccessful => "Deletion successful.";
            public static string DeletionFailed => "Deletion failed.";
            public static string EditFailed => "Edit Failed";
            public static string EditSucceeded => "Updated successfully";

            public static string CreateFailed => "Create Failed";
            public static string CreatedSuccessfully => "Created successfully";

            public static string FieldLength => "{0} should be atleast {1} characters long";
        }
    }
}
