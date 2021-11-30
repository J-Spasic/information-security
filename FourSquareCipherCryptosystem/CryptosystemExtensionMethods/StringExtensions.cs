using System.Linq;

namespace CryptosystemExtensionMethods
{
    public static class StringExtensions
    {
        #region Method(s)
        /// <summary>
        /// Gets only letters from given input string.
        /// </summary>
        /// <param name="inputString">String used to extract letters.</param>
        /// <returns>Letters from the input string if there are any; otherwise an empty string.</returns>
        public static string GetLettersOnly(this string inputString) =>
            new(inputString.Where(character => char.IsLetter(character)).ToArray());
        #endregion Method(s)
    }
}
