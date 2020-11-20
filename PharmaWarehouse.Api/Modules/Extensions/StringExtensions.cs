using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PharmaWarehouse.Api.Modules.Extensions
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstLetter(this string str)
        {
            string[] strings = str.Split("_");
            for (int i = 0; i < strings.Length; i++)
            {
                char[] characters = strings[i].ToCharArray();
                characters[0] = characters[0].ToString().ToUpper()[0];

                strings[i] = string.Join(string.Empty, characters);
            }

            return string.Join(string.Empty, strings);
        }

        public static string HashPassword(this string password, string saltKey)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(saltKey),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((character, index) =>
                    index > 0 && char.IsUpper(character)
                        ? "_" + character
                        : character.ToString()))
                .ToLower();
        }

        public static T Deserialize<T>(this string input)
            where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using var sr = new StringReader(input);
            return (T)ser.Deserialize(sr);
        }

        public static string Serialize<T>(this T objectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

            using StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, objectToSerialize);
            return textWriter.ToString();
        }

        public static string JsonSerialize<T>(this T objectToSerialize)
        {
            return JsonSerializer.Serialize(objectToSerialize);
        }

        public static T GetEnumValueFromDescription<T>(this string description)
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(
                    field,
                    typeof(DescriptionAttribute),
                    true) is DescriptionAttribute attribute)
                {
                    if (attribute.Description.Normalize() == description.Normalize())
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            return default;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1122:Use string.Empty for empty strings", Justification = "not required")]
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input[1..]
            };
    }
}
