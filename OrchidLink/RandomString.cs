namespace OrchidLink
{
	public class RandomString
	{
		public static string Generate(int size = 8)
		{
            Random random = new Random();
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string randomstring = "";

            for (int i = 0; i < size; i++)
            {
                int x = random.Next(str.Length);
                randomstring = randomstring + str[x];
            }

            return randomstring;
        }
	}
}
