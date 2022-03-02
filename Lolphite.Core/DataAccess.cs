using SQLite;

namespace Lolphite.Core
{
    /// <summary>
    /// A class for local storage of static/unchanging data. By calling class methods directly, an sqlite database will be created
    /// with a name "default.db3" in the app directory, otherwise call the constructor and set the fileName, to reuse or create multiple 
    /// different databases.
    /// </summary>
    public class DataAccess
    {

        private static string? fileName;
        public static string FileName
        {
            get 
            {
                if (fileName == null)
                    return "default";
                return fileName; 
            }
            set 
            { 
                fileName = value; 
            }
        }

        private static readonly string DBFile = Path.Combine(Environment.CurrentDirectory, $"{FileName}.db3");

        /// <summary>
        /// Create a separate database for different purpose.
        /// </summary>
        /// <param name="fileName"> Important notice: by creating a different database, be sure to always call a constructor in different parts
        /// of code with the same fileName, otherwise you might run into issues, where this class might try storing data in to default.db3 database.
        /// Unless you intend to only use the default.db3 database and only it, then calling this constructor is unecessary.</param>
        public DataAccess(string fileName)
        {
            FileName = fileName;
        }

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(DBFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Insert(item);

                if (rows > 0)
                    result = true;
            }

            return result;
        }
        public static List<T> Read<T>()
            where T : new()
        {
            List<T> items;

            using (SQLiteConnection conn = new SQLiteConnection(DBFile))
            {
                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }

            return items;
        }
        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(DBFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Update(item);

                if (rows > 0)
                    result = true;
            }

            return result;
        }
        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(DBFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Delete(item);

                if (rows > 0)
                    result = true;
            }

            return result;
        }

    }
}
