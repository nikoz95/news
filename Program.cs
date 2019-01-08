using System;
using System.IO;

namespace folderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Please enter a space separeted double Values : ");
            var paramList = Console.ReadLine().Split(' '); // ',' for comma separeted values
            var param1 = Convert.ToString(paramList[0]);
            var param2 = Convert.ToString(paramList[1]);
            if (!Directory.Exists(param1))
            {
                Console.WriteLine("not Exist this directory... please try again.");
            }
            
            else
            {
                DirectoryInfo ForOperation = new DirectoryInfo(param1);
                switch (param2)
                {
                    case "1":
                        Console.WriteLine("The size is {0} MegaBytes.", DirSize(ForOperation).ToSize(MyExtension.SizeUnits.MB));
                        Console.WriteLine("The size is {0} KiloBytes.", DirSize(ForOperation).ToSize(MyExtension.SizeUnits.KB));
                        Console.WriteLine("The size is {0} Bytes.", DirSize(ForOperation));
                        break;
                    case "2":
                        Check(param1, 1);
                        break;
                    default:
                        Console.WriteLine($"An unexpected value... please try again.");
                        break;
                }

            }
            //Console.WriteLine("Enter Folder Url:");
            //string url  =  Console.ReadLine();

            //if (!Directory.Exists(url))
            //{
            //    Console.WriteLine("not Exist this directory... please try again.");
            //}
            //else
            //{
            //Console.WriteLine("Enter Operation: (1)-Folder Volume or (2)-Folder Volume Details ");
            //string s = Console.ReadLine();
            //    DirectoryInfo ForOperation=new DirectoryInfo(@url);
            //    switch (s)
            //    {
            //        case "1":
            //            Console.WriteLine("The size is {0} MegaBytes.", DirSize(ForOperation).ToSize(MyExtension.SizeUnits.MB));
            //            Console.WriteLine("The size is {0} KiloBytes.", DirSize(ForOperation).ToSize(MyExtension.SizeUnits.KB));
            //            Console.WriteLine("The size is {0} Bytes.", DirSize(ForOperation));
            //            break;
            //        case "2":
            //            Check(url, 1);
            //            break;
            //        default:
            //             Console.WriteLine($"An unexpected value... please try again.");
            //            break;
            //    }

            //}



           





            //System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(@"C:\Users\Niko\Desktop\test\");



            // long size = 0;    


            // FileInfo[] f1 = dirInfo.GetFiles();
            // foreach (FileInfo f1s in f1) 
            // {      
            //     size = f1s.Length;  
            //     Console.WriteLine("-{0}(FileName)(Size:{1}KB)",f1s.Name,size.ToSize(MyExtension.SizeUnits.KB));  
            //     DirectoryInfo[] dis1 = dirInfo.GetDirectories();
            //     foreach (DirectoryInfo dis1s in dis1){

            //         Console.WriteLine("-{0}(FolderName)(FolderSize:{1}KB)",dis1s.Name,DirSizeWithOutSub(dis1s).ToSize(MyExtension.SizeUnits.KB));
            //         FileInfo[] f2 = dis1s.GetFiles();
            //         DirectoryInfo[] dis2 = dis1s.GetDirectories();
            //         foreach(FileInfo f2s in f2){
            //             size = f2s.Length;
            //             Console.WriteLine("----{0}(FileName)(Size:{1}KB)",f2s.Name,size.ToSize(MyExtension.SizeUnits.KB));
            //         }


            //         foreach(DirectoryInfo dis2s in dis2) {

            //             FileInfo[] f3 = dis2s.GetFiles();
            //             Console.WriteLine("--{0}(FolderName)(FolderSize:{1}KB)",dis2s.Name,DirSizeWithOutSub(dis2s).ToSize(MyExtension.SizeUnits.KB));
            //             foreach(FileInfo f3s in f3){
            //                 size = f3s.Length;
            //                 Console.WriteLine("----{0}(FileName)(Size:{1}KB)",f3s.Name,size.ToSize(MyExtension.SizeUnits.KB));
            //             }


            //         }
            //     } 

            // }

            //Check(@"C:\Users\Niko\Desktop\test",1);








            // System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");
            // foreach (System.IO.DirectoryInfo d in dirInfos)
            //     {
            //         Console.WriteLine("--"+d.Name);

            //         System.IO.DirectoryInfo[] ddirInfos = d.GetDirectories("*.*");
            //         foreach(System.IO.DirectoryInfo dd in ddirInfos){
            //                 Console.WriteLine("----"+dd.Name);
            //         }
            //     }



        }


        static public bool PlayAgain()
            {
                while (true) // Continue asking until a correct answer is given.
                {
                    Console.Write("Do you want to play again [Y/N]?");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                        return true;
                    if (answer == "N")
                        return false;
                }
            }

        public static long DirSize(DirectoryInfo d) 
        {    
                long size = 0;    
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis) 
                {      
                    size += fi.Length;    
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis) 
                {
                    size += DirSize(di);   
                }
                return size;  
        }

     public static long DirSizeWithOutSub(DirectoryInfo d) 
        {    
                long size = 0;    
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis) 
                {      
                    size += fi.Length;    
                }
               return size;
        }
        
     static void  Check(string link, int c){
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(@link);

            long size = 0;    
            //Console.WriteLine("eeeeee"+c);
            if(c==1){
                Console.WriteLine("{2} {0}(FolderName)(FolderSize:{1}KB)",dirInfo.Name,DirSizeWithOutSub(dirInfo).ToSize(MyExtension.SizeUnits.KB),dash(c));
            }
            FileInfo[] f1 = dirInfo.GetFiles();
            DirectoryInfo[] dis1 = dirInfo.GetDirectories();
            
            foreach (FileInfo f1s in f1) 
            {      
                size = f1s.Length;  
                Console.WriteLine("{2} {0}(FileName)(Size:{1}KB)",f1s.Name,size.ToSize(MyExtension.SizeUnits.KB),dash(c));  
            }
            foreach (DirectoryInfo dis1s in dis1){
                Console.WriteLine("{2} {0}(FolderName)(FolderSize:{1}KB)",dis1s.Name,DirSizeWithOutSub(dis1s).ToSize(MyExtension.SizeUnits.KB), dash(c));
                //FileInfo[] f2 = dis1s.GetFiles();
                //DirectoryInfo[] dis2 = dis1s.GetDirectories();
                // foreach(FileInfo f2s in f2){
                //     size = f2s.Length;
                //     Console.WriteLine("----{0}(FileName)(Size:{1}KB)",f2s.Name,size.ToSize(MyExtension.SizeUnits.KB));
                // }
                // foreach(DirectoryInfo dis2s in dis2) {
                
                //     FileInfo[] f3 = dis2s.GetFiles();
                //     Console.WriteLine("--{0}(FolderName)(FolderSize:{1}KB)",dis2s.Name,DirSizeWithOutSub(dis2s).ToSize(MyExtension.SizeUnits.KB));
                //     foreach(FileInfo f3s in f3){
                //         size = f3s.Length;
                //         Console.WriteLine("----{0}(FileName)(Size:{1}KB)",f3s.Name,size.ToSize(MyExtension.SizeUnits.KB));
                //     }
                // }
                
                string l = @""+dis1s+"";
               
                Check(l,c+5);
                
            } 

     }      

    static string  dash(int number){
        string dash="-";

        for (int i = 0; i < number; i++)
        {
            dash+="-";
        }        
            
        return dash;
    }    


    }
}
