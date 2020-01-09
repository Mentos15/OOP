using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;
using System.IO.Compression;


namespace Lab13
{
    public class EVSLog
    {
        public void Time(string info)
        {
            FileInfo file = new FileInfo(info);
            string curTimeLong = DateTime.Now.ToLongTimeString();

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Виталий\ООП\13_Laba\Lab13\Lab13\bin\Debug\EVSlog.txt", true))
            {
                sw.WriteLine("Время и дата создания файла - " + file.CreationTime);
               
            }
        }
        public void Directory(string path)
        {
            FileInfo file = new FileInfo(path);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Виталий\ООП\13_Laba\Lab13\Lab13\bin\Debug\EVSlog.txt", true))
            {
               
                sw.WriteLine("Путь до папки - " + file.DirectoryName);
                sw.WriteLine("\n -------------------------------------------- \n");
            }
        }
        public void Name(string path)
        {
            FileInfo file = new FileInfo(path);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Виталий\ООП\13_Laba\Lab13\Lab13\bin\Debug\EVSlog.txt", true))
            {

                sw.WriteLine("Имя файла - " + file.Name);
            }
        }
    }
    class EVSDiskInfo
    {
        public void FreeDiskSpace(string name)
        {
            DriveInfo di = new DriveInfo(name);
            
           
            WriteLine("Свободно на введеном диске места: "+di.TotalFreeSpace);
            WriteLine("\n -------------------------------------------- \n");
        }
        public void AllInfoDisk()
        {
            var space = DriveInfo.GetDrives();
            foreach (var d in space)
            {
                WriteLine("Имя диска: {0}", d.Name);
                WriteLine("Тип диска: {0}", d.DriveType);
                if (!d.IsReady) continue;
                WriteLine("Volume Label: {0}", d.VolumeLabel);
                WriteLine("Файловая система: {0}", d.DriveFormat);
                WriteLine("Корень: {0}", d.RootDirectory);
                WriteLine("Общий объем: {0}", d.TotalSize);
                WriteLine("общий объем свободного места на диске: {0}", d.TotalFreeSpace);
                WriteLine("Объем доступного свободного места на диске : {0}", d.AvailableFreeSpace);
                WriteLine("\n -------------------------------------------- \n");
            }
        }
        public void FileSystem(string name)
        {
            DriveInfo di = new DriveInfo(name);
            WriteLine("Файловая система указанного диска: " + di.DriveFormat);
            WriteLine("\n -------------------------------------------- \n");
        }
    }
    class EVSFileInfo
    {

        public void CreateTime(string path)
        {
            FileInfo file = new FileInfo(path);
            EVSLog log = new EVSLog();
            log.Time(path);
            WriteLine("Время и дата создания файла: "+file.CreationTime);
            WriteLine("\n -------------------------------------------- \n");
        }
        public void GetInfoFile(string path)
        {
            FileInfo file = new FileInfo(path);
            WriteLine("Размер файла: " + file.Length + " Байт");
            WriteLine("Расширение файла: "+ file.Extension);
            WriteLine("Имя файла: "+ file.Name);
            EVSLog log = new EVSLog();
            log.Name(path);
            WriteLine("\n -------------------------------------------- \n");
        }
        public void AllWay(string path)
        {
            FileInfo file = new FileInfo(path);
            EVSLog log = new EVSLog();
            log.Directory(path);
            WriteLine("Полный путь до файла: " + file.DirectoryName);
            WriteLine("\n -------------------------------------------- \n");
            
        }
    }
    class EVSDirInfo
    {
        public void GetValuFiles(string dirName)
        {
            string[] files = Directory.GetFiles(dirName);            WriteLine("Количество файлов в директории: "+files.Length);            WriteLine("\n -------------------------------------------- \n");
        }
        public void CreateTime(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            WriteLine("Время создания директории: " + dirInfo.CreationTime);
            WriteLine("\n -------------------------------------------- \n");
        }
        public void GetValueDirectorys(string dirName)
        {
            string[] dirs = Directory.GetDirectories(dirName);            WriteLine("Количество поддиректорий в директории: " + dirs.Length);
            WriteLine("\n -------------------------------------------- \n");
        }
        public void GetParents(string dirName)
        {
            DirectoryInfo dir = Directory.GetParent(dirName);
            WriteLine("Список родительских дерикторий: " + dir);
            WriteLine("\n -------------------------------------------- \n");

        }
    }
    class EVSFileManager
    {
        public void Manag(string path)
        {
            string filepath;
            Directory.CreateDirectory(filepath = path + "\\" + "EVSInspect");

            string filename;
            FileInfo fileInfo = new FileInfo(filename = filepath + "\\" + "EVSdirinfo.txt");

            EVSLog log = new EVSLog();
            log.Time(filename);
            log.Name(filename);
            log.Directory(filename);
            using (FileStream fstream = new FileStream(filename, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                if (Directory.Exists(path))
                {
                    sw.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(path);
                    foreach (string s in files)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine();
                    
                    sw.WriteLine("Дериктории:");
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string s in dirs)
                    {
                        sw.WriteLine(s);
                    }
                }
                sw.Close();
            }

            ReadKey();

            fileInfo.CopyTo("C:\\EVSInspect\\EVS2dirinfo.txt", true);
            fileInfo.Delete();

            string filecopydir;
            DirectoryInfo dInfo = new DirectoryInfo(filecopydir = path + "EVSFiles");
            dInfo.Create();

            string[] files2 = Directory.GetFiles(@"C:\Users\Виталий\ООП\13_Laba\Lab13\Lab13","*.cs");

            foreach (string s in files2)
            {
                File.Copy(s, filecopydir + "\\" + new FileInfo(s).Name);
            }
            


        }
        public void GetArchive(string path)
        {
            string path2 = "C:\\Users\\Виталий\\ООП\\13_Laba\\Archive.zip";
            ZipFile.CreateFromDirectory(path, path2);
            EVSLog log = new EVSLog();
            log.Time(path2);
            log.Name(path2);
            log.Directory(path2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            EVSLog log = new EVSLog();
            log.Time(@"D:\in.txt");
            log.Name(@"D:\in.txt");
            log.Directory(@"D:\in.txt");
            WriteLine("---------------- 2 Задание ---------------- ");
            EVSDiskInfo disk = new EVSDiskInfo();
            disk.FreeDiskSpace(@"C:\");
            disk.AllInfoDisk();
            disk.FileSystem(@"D:\");
            WriteLine("\n ---------------- 3 Задание ---------------- ");
            string path = @"C:\Users\Виталий\file.txt";
            EVSFileInfo file = new EVSFileInfo();            file.CreateTime(path);            file.GetInfoFile(path);
            file.AllWay(path);
            WriteLine("\n ---------------- 4 Задание ---------------- ");
            string dirName = "C:\\Users\\Виталий\\ООП\\12_Laba\\LAB_12\\LAB_12";
            EVSDirInfo dir = new EVSDirInfo();
            dir.CreateTime(dirName);
            dir.GetValuFiles(dirName);
            dir.GetValueDirectorys(dirName);
            dir.GetParents(dirName);
            WriteLine("\n ---------------- 5 Задание ---------------- ");
            EVSFileManager manager = new EVSFileManager();
            manager.Manag("C:\\");
            manager.GetArchive("C:\\EVSInspect");
            string time = "14:23";
            
            string par1;
            string path33 = "EVSlog.txt";
            StreamReader sr = new StreamReader(path33, true);

            par1 = sr.ReadToEnd();
            string[] words = par1.Split(' ');
            for(int i = 0; i<words.Length;i++)
            {
              if(words[i].Contains(time))
              {
                WriteLine("Дата создания файла: "+words[i - 1]);
                WriteLine("Время создания файла: "+words[i]+ " Файла "+ words[i + 3]+ " до файла: " + words[i + 7]);
              }
            }


            

            ReadLine();

        }
    }
}
