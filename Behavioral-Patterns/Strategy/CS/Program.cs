using System;

namespace Strategy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ICompressor compressor = new RAR_Compression();
            IFormate formator = new JSON_Formate();
            var user = new User("timoninas", "123456", compressor, formator);

            user.CompressFormatedFile("user1", "txt");

            // FILE user1.txt
            // >>> RAR COMPRESSION <<<
            // {
            //     "message": Username: timoninas, Password: 123456
            // }
            // <<< RAR COMPRESSION >>>

            user.SetStrategy(new ZIP_Compression(), new XML_Formate());
            user.CompressFormatedFile("user2", "txt");

            // FILE user2.txt
            // ~~> ZIP COMPRESSION < ~~
            // < article lang = "" >
            // < para > Message: Username: timoninas, Password: 123456 </ para >
            // </ article >
            // < ~~ZIP COMPRESSION~~>
        }
    }
}
