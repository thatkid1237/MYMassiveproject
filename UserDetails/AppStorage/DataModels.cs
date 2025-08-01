namespace Linkedlistsstory.UserDetails.AppStorage 
{ 
    public class AccountData
    {
        public int Id { get; set; }
   
        public string Username { get; set; }
    
        public string Password { get; set; }
        public AccountSettings Settings { get; set; }

        //public string ProfilePicturePath { get; set; }
    }
    public class AccountSettings
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public string Theme { get; set; } = "Light"; // Default theme
    
        //public String BackGroundPath { get; set; } = "Assets/Backgrounds/default.jpg"; // Default background path
    
        //public string TimeZone { get; set; } = "UTC"; // Default time zone
    
        //public string FontSize { get; set; } = "Medium"; // Default font size

        public AccountData AccountData { get; set; } // Navigation property for the related AccountData
    }
}