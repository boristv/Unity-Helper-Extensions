namespace SG.Extensions
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Return sign of bool (true => 1, false => -1)
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int Sign(this bool self) => self ? 1 : -1;

        /// <summary>
        /// Convert bool to int (true => 1, false => 0)
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static int ToInt(this bool self) => self ? 1 : 0;
    }
}