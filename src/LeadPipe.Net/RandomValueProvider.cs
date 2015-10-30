// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomValueProvider.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeadPipe.Net
{
    /// <summary>
    /// An enumeration of different age groups.
    /// </summary>
    public enum AgeGroup
    {
        /// <summary>
        /// Any (0-max years)
        /// </summary>
        Any,

        /// <summary>
        /// Infants (0-12 months)
        /// </summary>
        Infant,

        /// <summary>
        /// Toddlers (1-3 years)
        /// </summary>
        Toddler,

        /// <summary>
        /// Preschoolers (3-5 years)
        /// </summary>
        Preschooler,

        /// <summary>
        /// Gradeschoolers (5-12 years)
        /// </summary>
        Gradeschooler,

        /// <summary>
        /// Teens (12-18 years)
        /// </summary>
        Teen,

        /// <summary>
        /// Adults (18-max years)
        /// </summary>
        Adult,

        /// <summary>
        /// Seniors (65-max years)
        /// </summary>
        Senior
    }

    /// <summary>
    /// An enumeration of genders.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Gender unspecified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// A female.
        /// </summary>
        Female = 1,

        /// <summary>
        /// A male.
        /// </summary>
        Male = 2
    }

    /// <summary>
    /// Provides random values.
    /// </summary>
    public static class RandomValueProvider
    {
        #region Constants and Fields

        /// <summary>
        /// The last names.
        /// </summary>
        public static readonly string[] LastNames = new[]
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson",
            "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White",
            "Lopez", "Lee", "Gonzalez", "Harris", "Clark", "Lewis", "Robinson", "Walker", "Perez", "Hall", "Young",
            "Allen", "Sanchez", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill", "Ramirez",
            "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans", "Turner", "Torres", "Parker", "Collins",
            "Edwards", "Stewart", "Flores", "Morris", "Nguyen", "Murphy", "Rivera", "Cook", "Rogers", "Morgan",
            "Peterson", "Cooper", "Reed", "Bailey", "Bell", "Gomez", "Kelly", "Howard", "Ward", "Cox", "Diaz",
            "Richardson", "Wood", "Watson", "Brooks", "Bennett", "Gray", "James", "Reye", "Cruz", "Hughes", "Price",
            "Myers", "Long", "Foster", "Sanders", "Ross", "Morales", "Powell", "Sullivan", "Russell", "Ortiz", "Jenkins",
            "Gutierrez", "Perry", "Butler", "Barnes", "Fisher", "Major"
        };

        /// <summary>
        /// The female first names.
        /// </summary>
        private static readonly string[] FemaleFirstNames = new[]
        {
            "Mary", "Patricia", "Linda", "Barbara", "Elizabeth", "Jennifer", "Maria", "Susan", "Margaret", "Dorothy",
            "Lisa", "Nancy", "Karen", "Betty", "Helen", "Sandra", "Donna", "Carol", "Ruth", "Sharon", "Michelle",
            "Laura", "Sarah", "Kimberly", "Deborah", "Jessica", "Shirley", "Cynthia", "Angela", "Melissa", "Brenda",
            "Amy", "Anna", "Rebecca", "Virginia", "Kathleen", "Pamela", "Martha", "Debra", "Amanda", "Stephani",
            "Carolyn", "Christine", "Marie", "Janet", "Catherine", "Frances", "Ann", "Joyce", "Diane", "Alice", "Julie",
            "Heather", "Teresa", "Doris", "Gloria", "Evelyn", "Jean", "Cheryl", "Mildred", "Katherine", "Joan", "Ashley",
            "Judith", "Rose", "Janice", "Kelly", "Nicole", "Judy", "Christina", "Kathy", "Theresa", "Beverly", "Denise",
            "Tammy", "Irene", "Jane", "Lori", "Rachel", "Marilyn", "Andrea", "Kathryn", "Louise", "Sara", "Anne",
            "Jacqueline", "Wanda", "Bonnie", "Julia", "Ruby", "Lois", "Tina", "Phyllis", "Norma", "Paula", "Diana",
            "Annie", "Lillian", "Emily", "Robin", "Peggy", "Crystal", "Gladys", "Rita", "Dawn", "Connie", "Florence",
            "Tracy", "Edna", "Tiffany", "Carmen", "Rosa", "Cindy", "Grace", "Wendy", "Victoria", "Edith", "Kim",
            "Sherry", "Sylvia", "Josephine", "Thelma", "Shannon", "Sheila", "Ethel", "Ellen", "Elaine", "Marjorie",
            "Carrie", "Charlotte", "Monica", "Esther", "Pauline", "Emma", "Juanita", "Anita", "Rhonda", "Hazel", "Amber",
            "Eva", "Debbie", "April", "Leslie", "Clara", "Lucille", "Jamie", "Joanne", "Eleanor", "Valerie", "Danielle",
            "Megan", "Alicia", "Suzanne", "Michele", "Gail", "Bertha", "Darlene", "Veronica", "Jill", "Erin",
            "Geraldine", "Lauren", "Cathy", "Joann", "Lorraine", "Lynn", "Sally", "Regina", "Erica", "Beatrice",
            "Dolores", "Bernice", "Audrey", "Yvonne", "Annette", "June", "Samantha", "Marion", "Dana", "Stacy", "Ana",
            "Renee", "Ida", "Vivian", "Roberta", "Holly", "Brittany", "Melanie", "Loretta", "Yolanda", "Jeanette",
            "Laurie", "Katie", "Kristen", "Vanessa", "Alma", "Sue", "Elsie", "Beth", "Jeanne", "Vicki", "Carla", "Tara",
            "Rosemary", "Eileen", "Terri", "Gertrude", "Lucy", "Tonya", "Ella", "Stacey", "Wilma", "Gina", "Kristin",
            "Jessie", "Natalie", "Agnes", "Vera", "Willie", "Charlene", "Bessie", "Delores", "Melinda", "Pearl",
            "Arlene", "Maureen", "Colleen", "Allison", "Tamara", "Joy", "Georgia", "Constance", "Lillie", "Claudia",
            "Jackie", "Marcia", "Tanya", "Nellie", "Minnie", "Marlene", "Heidi", "Glenda", "Lydia", "Viola", "Courtney",
            "Marian", "Stella", "Caroline", "Dora", "Jo", "Vickie", "Mattie", "Terry", "Maxine", "Irma", "Mabel",
            "Marsha", "Myrtle", "Lena", "Christy", "Deanna", "Patsy", "Hilda", "Gwendolyn", "Jennie", "Nora", "Margie",
            "Nina", "Cassandra", "Leah", "Penny", "Kay", "Priscilla", "Naomi", "Carole", "Brandy", "Olga", "Billie",
            "Dianne", "Tracey", "Leona", "Jenny", "Felicia", "Sonia", "Miriam", "Velma", "Becky", "Bobbie", "Violet",
            "Kristina", "Toni", "Misty", "Mae", "Shelly", "Daisy", "Ramona", "Sherri", "Erika", "Katrina", "Claire",
            "Lindsay", "Maci"
        };

        /// <summary>
        /// The lorem ipsum words.
        /// </summary>
        private static readonly string[] LoremIpsumWords = new[]
            {
                "consetetur", "sadipscing", "elitr", "sed", "diam", "nonumy", "eirmod", "tempor", "invidunt", "ut", "labore", "et",
                "dolore", "magna", "aliquyam", "erat", "sed", "diam", "voluptua", "at", "vero", "eos", "et", "accusam", "et",
                "justo", "duo", "dolores", "et", "ea", "rebum", "stet", "clita", "kasd", "gubergren", "no", "sea", "takimata",
                "sanctus", "est", "lorem", "ipsum", "dolor", "sit", "amet", "lorem", "ipsum", "dolor"
            };

        /// <summary>
        /// The male first names.
        /// </summary>
        private static readonly string[] MaleFirstNames = new[]
        {
            "James", "John", "Robert", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas",
            "Christopher", "Daniel", "Paul", "Mark", "Donald", "George", "Kenneth", "Steven", "Edward", "Brian",
            "Ronald", "Anthony", "Kevin", "Jason", "Matthew", "Gar", "Timothy", "Jose", "Larry", "Jeffrey", "Frank",
            "Scott", "Eric", "Stephen", "Andrew", "Raymond", "Gregory", "Joshua", "Jerry", "Dennis", "Walter", "Patrick",
            "Peter", "Harold", "Douglas", "Henry", "Carl", "Arthur", "Ryan", "Roger", "Joe", "Juan", "Jack", "Albert",
            "Jonathan", "Justin", "Terry", "Gerald", "Keith", "Samuel", "Willie", "Ralph", "Lawrence", "Nicholas", "Roy",
            "Benjami", "Bruce", "Brando", "Adam", "Harry", "Fred", "Wayne", "Billy", "Steve", "Louis", "Jeremy", "Aaron",
            "Randy", "Howard", "Eugen", "Carlos", "Russell", "Bobby", "Victor", "Martin", "Ernest", "Phillip", "Todd",
            "Jesse", "Craig", "Alan", "Sha", "Clarence", "Sean", "Philip", "Chris", "Johnny", "Earl", "Jimmy", "Antonio",
            "Danny", "Bryan", "Tony", "Luis", "Mike", "Stanley", "Leonard", "Nathan", "Dale", "Manuel", "Rodney",
            "Curtis", "Norman", "Allen", "Marvin", "Vincent", "Glenn", "Jeffery", "Travis", "Jeff", "Chad", "Jacob",
            "Lee", "Melvin", "Alfred", "Kyle", "Francis", "Bradley", "Jesus", "Herbert", "Frederick", "Ray", "Joel",
            "Edwin", "Don", "Eddie", "Ricky", "Troy", "Randall", "Barry", "Alexander", "Bernard", "Mario", "Leroy",
            "Francisco", "Marcus", "Micheal", "Theodore", "Clifford", "Miguel", "Oscar", "Jay", "Jim", "Tom", "Calvin",
            "Alex", "Jon", "Ronnie", "Bill", "Lloyd", "Tommy", "Leon", "Derek", "Warren", "Darrell", "Jerome", "Floyd",
            "Leo", "Alvin", "Tim", "Wesley", "Gordon", "Dean", "Greg", "Jorge", "Dustin", "Pedro", "Derrick", "Dan",
            "Lewis", "Zachary", "Corey", "Herman", "Maurice", "Vernon", "Roberto", "Clyde", "Glen", "Hector", "Shane",
            "Ricardo", "Sam", "Rick", "Lester", "Brent", "Ramon", "Charlie", "Tyler", "Gilbert", "Gene", "Marc",
            "Reginald", "Ruben", "Brett", "Angel", "Nathaniel", "Rafael", "Leslie", "Edgar", "Milton", "Raul", "Ben",
            "Chester", "Cecil", "Duane", "Franklin", "Andre", "Elmer", "Brad", "Gabriel", "Ron", "Mitchell", "Roland",
            "Arnold", "Harvey", "Jared", "Adrian", "Karl", "Cory", "Claude", "Erik", "Darryl", "Jamie", "Neil", "Jessie",
            "Christian", "Javier", "Fernando", "Clinton", "Ted", "Mathew", "Tyrone", "Darren", "Lonnie", "Lance", "Cody",
            "Julio", "Kelly", "Kurt", "Allan", "Nelson", "Gu", "Clayton", "Hug", "Max", "Dwayne", "Dwight", "Armando",
            "Felix", "Jimmie", "Everett", "Jordan", "Ian", "Wallace", "Ken", "Bob", "Jaime", "Casey", "Alfredo",
            "Alberto", "Dave", "Ivan", "Johnnie", "Sidney", "Byron", "Julian", "Isaac", "Morris", "Clifton", "Willard",
            "Daryl", "Ros", "Virgil", "Andy", "Marshall", "Salvador", "Perry", "Kirk", "Sergio", "Marion", "Tracy",
            "Seth", "Kent", "Terrance", "Rene", "Eduardo", "Terrence", "Enrique", "Freddie", "Wade"
        };

        /// <summary>
        /// The name prefixes.
        /// </summary>
        private static readonly string[] NamePrefixes = new[]
        {
            "", "Ms.", "Miss.", "Mrs.", "Mr.", "Master.", "Rev.", "Fr.", "Dr.", "Atty.", "Prof.", "Hon.", "Pres.", "Gov.",
            "Coach.", "Ofc.", "Msgr.", "Sr.", "Br.", "Supt.", "Rep.", "Sen.", "Amb.", "Treas.", "Sec.", "Pvt.", "Cpl.",
            "Sgt.", "Adm.", "Maj.", "Capt.", "Cmdr.", "Lt.", "Lt Col.", "Col.", "Gen."
        };

        /// <summary>
        /// The name suffixes.
        /// </summary>
        private static readonly string[] NameSuffixes = new[]
        {
            "", "CFRE", "CLU", "CPA", "D.C.", "D.D.", "D.D.S.", "D.M.D.", "D.O.", "D.V.M.", "Ed.D.", "Esq.", "II", "III",
            "IV", "J.D.", "Jr.", "LL.D.", "M.D.", "O.D.", "Ph.D.", "Ret.", "R.N.", "R.N.C.", "Sr."
        };

        /// <summary>
        /// The random seed.
        /// </summary>
        private static readonly Random RandomSeed = new Random();

        private static readonly string[] TopLevelDomains = new[]
                {
            "com", "org", "edu", "gov", "co.uk", "net", "io"
        };

        #endregion Constants and Fields

        #region Public Methods

        /// <summary>
        /// Gets a string of lorem ipsum.
        /// </summary>
        /// <param name="numberOfWords">The number of words.</param>
        /// <returns>
        /// A string consisting of lorem ipsum words ("Lorem ipsum dolor sit amet sed diam.").
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public static string LoremIpsum(int numberOfWords)
        {
            var result = new StringBuilder();

            result.Append("Lorem ipsum dolor sit amet");

            var random = new Random();

            for (var i = 0; i <= numberOfWords; i++)
            {
                result.Append(" " + LoremIpsumWords[random.Next(LoremIpsumWords.Length - 1)]);
            }

            result.Append(".");

            return result.ToString();
        }

        /// <summary>
        /// Gets a random age.
        /// </summary>
        /// <param name="ageGroup">The (optional) age group.</param>
        /// <returns>An integer within the specified age group range.</returns>
        public static int RandomAge(AgeGroup ageGroup = AgeGroup.Any)
        {
            const int maximumAge = 120;
            const int minimumAge = 0;

            switch (ageGroup)
            {
                case AgeGroup.Any:
                    return RandomInteger(minimumAge, maximumAge);

                case AgeGroup.Infant:
                    return RandomInteger(minimumAge, 1);

                case AgeGroup.Toddler:
                    return RandomInteger(1, 3);

                case AgeGroup.Preschooler:
                    return RandomInteger(3, 5);

                case AgeGroup.Gradeschooler:
                    return RandomInteger(5, 12);

                case AgeGroup.Teen:
                    return RandomInteger(12, 18);

                case AgeGroup.Adult:
                    return RandomInteger(18, maximumAge);

                case AgeGroup.Senior:
                    return RandomInteger(65, maximumAge);

                default:
                    return RandomInteger(minimumAge, maximumAge);
            }
        }

        /// <summary>
        /// Returns a random Boolean value.
        /// </summary>
        /// <returns>A random Boolean value.</returns>
        public static bool RandomBool()
        {
            return RandomSeed.NextDouble() > 0.5;
        }

        /// <summary>
        /// Generates a random date between the date and times specified.
        /// </summary>
        /// <param name="minimum">The minimum date and time.</param>
        /// <param name="maximum">The maximum date and time.</param>
        /// <returns>A random date and time.</returns>
        public static DateTime RandomDateTime(DateTime minimum, DateTime maximum)
        {
            // Set the range...
            var range = new TimeSpan(maximum.Ticks - minimum.Ticks);

            // Fire up a new random date and time...
            return minimum + new TimeSpan((long)(range.Ticks * RandomSeed.NextDouble()));
        }

        /// <summary>
        /// Generates a random date between the years specified.
        /// </summary>
        /// <param name="minimumYear">The minimum year.</param>
        /// <param name="maximumYear">The maximum year.</param>
        /// <returns>A random date between the min and max years.</returns>
        public static DateTime RandomDateTime(int minimumYear, int maximumYear)
        {
            var minimum = new DateTime(minimumYear);
            var maximum = new DateTime(maximumYear);

            return RandomDateTime(minimum, maximum);
        }

        /// <summary>
        /// Returns a random email address.
        /// </summary>
        /// <returns>A random email address.</returns>
        public static string RandomEmailAddress()
        {
            var tld = RandomTopLevelDomain();

            return "{0}@{1}.{2}".FormattedWith(RandomString(10, true), RandomString(10, true), tld);
        }

        /// <summary>
        /// Returns a random first name with an optional gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <returns>A random first name.</returns>
        public static string RandomFirstName(Gender gender = Gender.Unspecified, bool includePrefix = false)
        {
            var firstName = string.Empty;

            switch (gender)
            {
                case Gender.Female:
                    firstName = FemaleFirstNames[RandomInteger(0, FemaleFirstNames.Length)];
                    break;

                case Gender.Male:
                    firstName = MaleFirstNames[RandomInteger(0, MaleFirstNames.Length)];
                    break;

                default:
                    firstName = FemaleFirstNames.Concat(MaleFirstNames).ToArray()[RandomInteger(0, (FemaleFirstNames.Length + MaleFirstNames.Length))];
                    break;
            }

            return includePrefix ? string.Concat(RandomNamePrefix(), " ", firstName) : firstName;
        }

        /// <summary>
        /// Returns a random full name with an optional gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <param name="separator">The separator string to use between the two parts of the name.</param>
        /// <param name="lastNameFirst">if set to <c>true</c> the last name will be first.</param>
        /// <param name="includePrefix">if set to <c>true</c> a prefix will be included.</param>
        /// <param name="includeSuffix">if set to <c>true</c> a suffix will be included.</param>
        /// <returns>A random full name.</returns>
        public static string RandomFullName(Gender gender = Gender.Unspecified, string separator = " ", bool lastNameFirst = false, bool includePrefix = false, bool includeSuffix = false)
        {
            var firstName = string.Empty;

            switch (gender)
            {
                case Gender.Female:
                    firstName = RandomFirstName(Gender.Female, includePrefix);
                    break;

                case Gender.Male:
                    firstName = RandomFirstName(Gender.Male, includePrefix);
                    break;

                default:
                    firstName = RandomFirstName(includePrefix: includePrefix);
                    break;
            }

            var lastName = RandomLastName(includeSuffix);

            return lastNameFirst ? string.Concat(lastName, separator, firstName) : string.Concat(firstName, separator, lastName);
        }

        /// <summary>
        /// Returns a random gender.
        /// </summary>
        /// <returns>Gender.</returns>
        public static Gender RandomGender()
        {
            var values = Enum.GetValues(typeof(Gender));

            return (Gender)values.GetValue(RandomSeed.Next(values.Length));
        }

        /// <summary>
        /// Returns a random integer.
        /// </summary>
        /// <param name="min">The minimum random integer boundary.</param>
        /// <param name="max">The maximum random integer boundary.</param>
        /// <returns>A random integer.</returns>
        public static int RandomInteger(int min, int max)
        {
            var returnValue = RandomSeed.Next(min, max);

            // TODO: This MIGHT result in a stack overflow.

            return returnValue.IsBetween(min, max) ? returnValue : RandomInteger(min, max);
        }

        /// <summary>
        /// Returns a random IPV4 address.
        /// </summary>
        /// <returns>A random IPV4 address.</returns>
        public static string RandomIpV4()
        {
            var partA = RandomInteger(0, 255);
            var partB = RandomInteger(0, 255);
            var partC = RandomInteger(0, 255);
            var partD = RandomInteger(0, 255);

            return string.Concat(partA.ToString(), ".", partB.ToString(), ".", partC.ToString(), ".", partD.ToString());
        }

        /// <summary>
        /// Gets random keys from a dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>An enumeration of random keys.</returns>
        /// <example>
        /// <code>
        /// Dictionary&lt;string, object%gt; dict = GetDictionary();
        /// foreach (string key in RandomKey(dict).Take(10))
        /// {
        /// Console.WriteLine(value);
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// Bear in mind that this method does not concern itself with uniqueness. In other words,
        /// it may return a key from the dictionary more than once.
        /// </remarks>
        public static IEnumerable<TKey> RandomKeys<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var keys = dictionary.Keys.ToList();

            var size = dictionary.Count;

            while (true)
            {
                yield return keys[RandomSeed.Next(size)];
            }
        }

        /// <summary>
        /// Returns a random last name.
        /// </summary>
        /// <param name="includeSuffix">if set to <c>true</c> a suffix will be included.</param>
        /// <returns>A random last name.</returns>
        public static string RandomLastName(bool includeSuffix = false)
        {
            return includeSuffix ? string.Concat(LastNames[RandomInteger(0, LastNames.Length)], ", ", RandomNameSuffix()) : LastNames[RandomInteger(0, LastNames.Length)];
        }

        /// <summary>
        /// Returns a random name prefix.
        /// </summary>
        /// <returns>A random name prefix.</returns>
        public static string RandomNamePrefix()
        {
            return NamePrefixes[RandomInteger(0, NamePrefixes.Length)];
        }

        /// <summary>
        /// Returns a random name suffix.
        /// </summary>
        /// <returns>A random name suffix.</returns>
        public static string RandomNameSuffix()
        {
            return NameSuffixes[RandomInteger(0, NameSuffixes.Length)];
        }

        /// <summary>
        /// Returns a random phone number.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns>A random phone number.</returns>
        public static string RandomPhoneNumber(string separator = "-")
        {
            var areaCodeDigitA = RandomSeed.Next(2, 9);
            var areaCodeDigitB = RandomSeed.Next(0, 8);
            var areaCodeDigitC = RandomSeed.Next(0, 9);

            var areaCode = string.Concat(areaCodeDigitA, areaCodeDigitB, areaCodeDigitC);
            var exchangeCode = RandomSeed.Next(200, 999);
            var subscriberNumber = RandomSeed.Next(1000, 9999);

            return string.Concat(areaCode, separator, exchangeCode, separator, subscriberNumber);
        }

        /// <summary>
        /// Returns a random social security number.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns>A random social security number.</returns>
        public static string RandomSocialSecurityNumber(string separator = "-")
        {
            var firstPart = RandomSeed.Next(132, 921);
            var secondPart = RandomSeed.Next(12, 83);
            var thirdPart = RandomSeed.Next(1423, 9211);

            return string.Concat(firstPart, separator, secondPart, separator, thirdPart);
        }

        /// <summary>
        /// Generates a random string with the given length.
        /// </summary>
        /// <param name="size">Size of the string.</param>
        /// <param name="lowerCaseOnly">If true, generate a lowercase string.</param>
        /// <returns>A random string.</returns>
        public static string RandomString(int size, bool lowerCaseOnly = false)
        {
            var randomString = new StringBuilder(size);

            // ASCII start position (65 = A / 97 = a)...
            var start = lowerCaseOnly ? 97 : 65;

            // Add random chars...
            for (var i = 0; i < size; i++)
            {
                randomString.Append((char)((26 * RandomSeed.NextDouble()) + start));
            }

            return randomString.ToString();
        }

        /// <summary>
        /// Returns a random top level domain.
        /// </summary>
        /// <returns>A random top level domain.</returns>
        public static string RandomTopLevelDomain()
        {
            return TopLevelDomains[RandomInteger(0, TopLevelDomains.Length)];
        }

        /// <summary>
        /// Returns a random unsigned integer.
        /// </summary>
        /// <param name="max">The maximum random integer boundary.</param>
        /// <returns>A random unsigned integer.</returns>
        public static uint RandomUnsignedInteger(int max)
        {
            return (uint)RandomSeed.Next(0, max);
        }

        /// <summary>
        /// Gets random values from a dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>An enumeration of random values.</returns>
        /// <example>
        /// <code>
        /// Dictionary&lt;string, object%gt; dict = GetDictionary();
        /// foreach (object value in RandomValues(dict).Take(10))
        /// {
        /// Console.WriteLine(value);
        /// }
        /// </code>
        /// </example>
        /// <remarks>
        /// Bear in mind that this method does not concern itself with uniqueness. In other words,
        /// it may return a value from the dictionary more than once.
        /// </remarks>
        public static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var rand = new Random();

            var values = dictionary.Values.ToList();

            var size = dictionary.Count;

            while (true)
            {
                yield return values[rand.Next(size)];
            }
        }

        #endregion Public Methods
    }
}