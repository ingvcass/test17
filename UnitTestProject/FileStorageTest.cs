using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class FileStorageTest
    {
        public const string WRITE_EXCEPTION = "WRITING IS INCORRECT";
        public const string DELETE_EXCEPTION = "DELETING IS INCORRECT";
        public const string MAX_SIZE_EXCEPTION = "FILE IS BIGGER THEN MAX SIZE";
        public const string NULL_FILE_EXCEPTION = "NULL FILE WAS WRITTEN";

        public const string NULL_STRING = "";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string FILE_PATH_STRING2 = "@D:\\JDK.txt";
        public const string CONTENT_STRING = "Some text";
        public const string WRONG_SIZE_CONTENT_STRING = "TEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtext";
        public List<File> files = new List<File>();

        public const int NEW_SIZE = 5;

        [TestMethod]
        public void WriteTest()
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);

            String file = newFile.GetFilename();
            storage.Write(newFile);
            Assert.AreEqual(storage.IsExists(file), true, WRITE_EXCEPTION);
        }
        [TestMethod]
        public void WriteSameTest()
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);

            storage.Write(newFile);
            try
            {
                storage.Write(newFile);
            }
            catch (FileNameAlreadyExistsException) { return; }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void DeleteTest()
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);

            String file = newFile.GetFilename();
            storage.Write(newFile);
            storage.Delete(file);
            Assert.AreEqual(storage.IsExists(file), false, DELETE_EXCEPTION);
        }

        [TestMethod]
        public void DeleteAllTest()
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);
            storage.Write(newFile);
            String file = newFile.GetFilename();
            File newFile2 = new File(FILE_PATH_STRING2, CONTENT_STRING);
            storage.Write(newFile2);
            String file2 = newFile.GetFilename();
            storage.DeleteAllFiles();
            Assert.AreEqual(storage.IsExists(file2) && storage.IsExists(file), false, DELETE_EXCEPTION);
        }

        [TestMethod]
        public void WriteWrongSizeFileTest()
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            File newFile = new File(FILE_PATH_STRING, WRONG_SIZE_CONTENT_STRING);

            String file = newFile.GetFilename();
            storage.Write(newFile);
            Assert.AreEqual(storage.IsExists(file), false, MAX_SIZE_EXCEPTION);
        }

        [TestMethod]
        public void GetFilesTest()
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);
            storage.Write(newFile);
            files.Add(newFile);
            File newFile2 = new File(FILE_PATH_STRING2, CONTENT_STRING);
            files.Add(newFile2);
            storage.Write(newFile2);
            Assert.AreEqual(storage.GetFiles(), files, DELETE_EXCEPTION);
        }

        [TestMethod]
        public void GetFileTest() 
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            File newFile = new File(FILE_PATH_STRING, CONTENT_STRING);
            String file = newFile.GetFilename();
            storage.Write(newFile);
            Assert.AreEqual(storage.GetFile(file), newFile, WRITE_EXCEPTION);
        }

        [TestMethod]
        public void WriteEmptyFileTest()
        {
            FileStorage storage = new FileStorage(NEW_SIZE);
            try
            {
                File newFile = new File(null, null);
                storage.Write(newFile);
            }
            catch (NullReferenceException) { return; }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
