namespace MyMauiApp
{
    public class AuthService
    {
        // Store PIN using Preferences
        public void SetPin(string pin)
        {
            Preferences.Set("user_pin", pin);
            Console.WriteLine($"PIN saved: {pin}");
        }

        // Get stored PIN
        public string GetPin()
        {
            var pin = Preferences.Get("user_pin", "");
            Console.WriteLine($"PIN retrieved: {pin}");
            return pin;
        }

        // Check if PIN is correct
        public bool CheckPin(string enteredPin)
        {
            string storedPin = GetPin();
            bool match = storedPin == enteredPin;
            Console.WriteLine($"PIN check: {match}");
            return match;
        }

        // Store username in Preferences
        public void SetUsername(string username)
        {
            Preferences.Set("username", username);
            Console.WriteLine($"Username saved: {username}");
        }

        // Get username from Preferences
        public string GetUsername()
        {
            var username = Preferences.Get("username", "User");
            Console.WriteLine($"Username retrieved: {username}");
            return username;
        }

        // Check if user has setup PIN
        public bool HasPin()
        {
            string pin = GetPin();
            bool hasPin = !string.IsNullOrEmpty(pin);
            Console.WriteLine($"Has PIN: {hasPin}");
            return hasPin;
        }

        // Lock app
        public void LockApp()
        {
            Preferences.Set("is_locked", true);
            Console.WriteLine("App locked");
        }

        // Unlock app
        public void UnlockApp()
        {
            Preferences.Set("is_locked", false);
            Console.WriteLine("App unlocked");
        }

        // Check if locked
        public bool IsLocked()
        {
            bool locked = Preferences.Get("is_locked", true);
            Console.WriteLine($"Is locked: {locked}");
            return locked;
        }

        // Clear all data
        public void ClearAll()
        {
            Preferences.Remove("user_pin");
            Preferences.Remove("username");
            Preferences.Remove("is_locked");
            Console.WriteLine("All data cleared");
        }
    }
}