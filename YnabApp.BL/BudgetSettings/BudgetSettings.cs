using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabApp.BL.BudgetSettings
{
    public class BudgetSettings
    {
        private static string SettingsFolderPath
        {
            get { return System.IO.Path.Combine(ConfigManager.Env.LocalBinFolder, ConfigManager.App.BudgetCustomization.SettingsFolder); }
        }

        public static BudgetSettings Load(string budgetId)
        {
            EnsureSettingsFolderExists();

            string filePath = System.IO.Path.Combine(SettingsFolderPath, $"{budgetId}.json");
            if (!File.Exists(filePath))
            {
                return new BudgetSettings { BudgetId = budgetId };
            }
            else
            {
                string jsonSettings = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<BudgetSettings>(jsonSettings);
            }
        }

        public string BudgetId { get; set; }

        private string SettingsFileName
        {
            get { return $"{BudgetId}.json"; }
        }

        private string SettingsFilePath
        {
            get { return System.IO.Path.Combine(SettingsFolderPath, SettingsFileName); }
        }

        private static void EnsureSettingsFolderExists()
        {
            if (!Directory.Exists(SettingsFolderPath))
                Directory.CreateDirectory(SettingsFolderPath);
        }


        public List<PersonSetting> People { get; set; } = new List<PersonSetting>();

        public List<CategoryGroupColorSetting> CategoryGroupColors { get; set; } = new List<CategoryGroupColorSetting>();

        public void Save()
        {
            string jsonSettings = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

            EnsureSettingsFolderExists();
            File.WriteAllText(SettingsFilePath, jsonSettings);
        }

    }

    public class  PersonSetting : IEquatable<PersonSetting>
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public PersonSetting()
        {
                
        }

        public static PersonSetting CreateNew(string name)
        {
            return new PersonSetting
            {
                Name = name,
                Id = Guid.NewGuid().ToString().Replace("-", "")
            };
        }

        public List<AccountSetting> Accounts { get; set; } = new List<AccountSetting>();

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(PersonSetting other)
        {
            if (other is null)
                return false;

            //if (ReferenceEquals(this, other))
            //    return true;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PersonSetting);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }

        public static bool operator ==(PersonSetting left, PersonSetting right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(PersonSetting left, PersonSetting right)
        {
            return !(left == right);
        }
    }

    public class AccountSetting : IEquatable<AccountSetting>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public AccountSetting()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(AccountSetting other)
        {
            if (other is null) 
                return false;

            //if (ReferenceEquals(this, other)) 
            //    return true;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AccountSetting);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }

        public static bool operator ==(AccountSetting left, AccountSetting right)
        {
            if (left is null) 
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(AccountSetting left, AccountSetting right)
        {
            return !(left == right);
        }
    }

    public class CategoryGroupColorSetting : IEquatable<CategoryGroupColorSetting>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ColorSetting BackColor { get; set; }

        public ColorSetting ForeColor { get; set; }

        public CategoryGroupColorSetting()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(CategoryGroupColorSetting other)
        {
            if (other is null)
                return false;

            //if (ReferenceEquals(this, other)) 
            //    return true;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CategoryGroupColorSetting);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }

        public static bool operator ==(CategoryGroupColorSetting left, CategoryGroupColorSetting right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(CategoryGroupColorSetting left, CategoryGroupColorSetting right)
        {
            return !(left == right);
        }
    }

    public class ColorSetting : IEquatable<ColorSetting>
    {
        public int Red { get; set; }

        public int Green { get; set; }

        public int Blue { get; set; }

        public static ColorSetting CreateFromColor(Color color)
        {
            return new ColorSetting() { Red = color.R, Green = color.G, Blue = color.B };
        }

        public Color GetColor()
        {
            return Color.FromArgb(Red, Green, Blue);
        }

        public override string ToString()
        {
            return $"{Red}.{Green}.{Blue}";
        }

        public bool Equals(ColorSetting other)
        {
            if (other is null)
                return false;

            //if (ReferenceEquals(this, other)) 
            //    return true;

            return (Red == other.Red && Green == other.Green && Blue == other.Blue);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ColorSetting);
        }

        public override int GetHashCode()
        {
            return ToString()?.GetHashCode() ?? 0;
        }

        public static bool operator ==(ColorSetting left, ColorSetting right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(ColorSetting left, ColorSetting right)
        {
            return !(left == right);
        }
    }

}
