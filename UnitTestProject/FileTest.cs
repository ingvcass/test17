using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class FileTest
    {

        public const string SIZE_EXCEPTION = "Wrong size";
        public const string NAME_EXCEPTION = "Wrong name";
        public const string EXTENSION_EXCEPTION = "Wrong extension";
        public const string SPACE_STRING = " ";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public double lenght;


        [TestMethod]
        public void GetSizeTest()
        {
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);
            String content = CONTENT_STRING;

            lenght = content.Length / 2;
            Assert.AreEqual(newFile.GetSize(), lenght, SIZE_EXCEPTION);
        }
        [TestMethod]
        public void GetFilenameTest()
        {
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);
            String name = "JDK-intellij-downloader-info.txt";
            Assert.AreEqual(newFile.GetFilename(), name, NAME_EXCEPTION);
        }
        [TestMethod]
        public void GetExtensionTest()
        {
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);
            String extension = "txt";
            Assert.AreEqual(newFile.GetExtension(), extension, EXTENSION_EXCEPTION);
        }
    }
}
