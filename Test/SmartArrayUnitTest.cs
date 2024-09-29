using SmartArrayConsole;

namespace SmartArrayUnitTest
{
    [TestClass]
    public class SmartArrayUnitTest
    {
        const int SMART_ARRAY_SIZE = 5;

        // SmartArray should initialize with all zeros
        [TestMethod]
        public void ArrayStartWithAll_0s()
        {
            //Arrange
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            int actual = 0;

            //Act
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                actual = actual + testSmartArray.GetAtIndex(i);
            }

            //Assert
            int expected = 0;
            Assert.AreEqual(expected, actual, 0.000001, "SmartArray not initilized to all zeros");
        }

        // SmartArray should allow setting the 0 location
        [TestMethod]
        public void SetLocation_0()
        {
            //Arrange
            int index = 0;
            int val = 5;
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);

            //Act
            testSmartArray.SetAtIndex(index, val);

            //Assert
            int actual = testSmartArray.GetAtIndex(index);
            Assert.AreEqual(val, actual, 0.000001, "Did not set SmartArray loc 0 correctly");
        }

        [TestMethod]
        public void AddUniqueValAllIndexes()
        {
            //Arrange
            int[] verifyArray = { 1, 2, 3, 4, 5 };
            SmartArray testArray = new SmartArray(SMART_ARRAY_SIZE);

            //Act
            for(int i = 0;i<=SMART_ARRAY_SIZE-1;i++)
            {
                testArray.SetAtIndex((int)i, verifyArray[i]);
            }

            //Assert
            for(int i = 0; i<verifyArray.Length; i++)
            {
                //No variation value because if there is variation they are not equal and thus incorrect. 
                Assert.AreEqual(verifyArray[i], testArray.GetAtIndex(i), $"Value at index {i} does not match the value expected.");
            }
        }

        [TestMethod]
        public void FindValInArray()
        {
            //Assert
            int val = 4;
            int index = 2;
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);

            //Act
            testSmartArray.SetAtIndex(index, val);

            //Assert
            bool actual = testSmartArray.Find(val);
            Assert.IsTrue(actual, "Find was not able to find value in array.");
        }

        [TestMethod]
        public void Find_ValueNotInArray()
        {
            //Assert
            int val = 4;
            int index = 2;
            int badVal = 15;
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);

            //Act
            testSmartArray.SetAtIndex(index, val);

            //Assert
            bool actual = testSmartArray.Find(badVal);
            //No variation value because if there is variation they are not equal and thus incorrect. 
            Assert.IsFalse(actual, "Find found value in array that should not be present.");
        }

        [TestMethod]
        public void ResizeArray5To10()
        {
            //Assert
            int newArraySize = 10;
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);

            //Act
            testSmartArray.Resize(newArraySize);

            //Assert
            int actual = testSmartArray.Length;
            //No variation value because if there is variation they are not equal and thus incorrect.
            Assert.AreEqual(newArraySize, actual, "Resized array is not the correct length.");
        }

        [TestMethod]
        public void ResizeArray5to10ValuesKept()
        {
            //Arrange
            int newArraySize = 10;
            int[] verifyArray = { 1, 2, 3, 4, 5 };
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            for(int i = 0; i < verifyArray.Length; i++)
            {
                testSmartArray.SetAtIndex(i, verifyArray[i]);
            }

            //Act
            testSmartArray.Resize(newArraySize);

            //Assert
            for(int i = 0;i < verifyArray.Length; i++)
            {
                bool actual = testSmartArray.Find(verifyArray[i]);
                Assert.IsTrue(actual, "Value was not present in small to large resized array when it should be.");
            }
        }

        [TestMethod]
        public void ResizeArray10To5Indexes()
        {
            //Arrage
            int largeArraySize = 10;
            SmartArray testSmartArray = new SmartArray(largeArraySize);

            //Act
            testSmartArray.Resize(SMART_ARRAY_SIZE);

            //Assert
            int actual = testSmartArray.Length;
            //No variation value because if there is variation they are not equal and thus incorrect. 
            Assert.AreEqual(SMART_ARRAY_SIZE, actual, "Resized Array from 10 to 5 did not size correctly.");
        }

        [TestMethod]
        public void ResizeArray10to5ValuesKept()
        {
            //Arrange
            int largeArraySize = 10;
            int[] verifyArray = { 1, 2, 3, 4, 5 };
            SmartArray testSmartArray = new SmartArray(largeArraySize);
            for (int i = 0; i < verifyArray.Length; i++)
            {
                testSmartArray.SetAtIndex(i, verifyArray[i]);
            }

            //Act
            testSmartArray.Resize(SMART_ARRAY_SIZE);

            //Assert
            for (int i = 0; i < verifyArray.Length; i++)
            {
                bool actual = testSmartArray.Find(verifyArray[i]);
                Assert.IsTrue(actual, "Value was not present in large to small resized array when it should be.");
            }
        }
    }

    [TestClass]
    public class UnitTest2
    {
        const int SMART_ARRAY_SIZE = 5;
        // SmartArray throw exception trying to set location greater than size of array
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetBadLocationAtSizeOfArrayValue()
        {
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(SMART_ARRAY_SIZE, 15);
            // assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetBadLocationNegativeIndex()
        {
            int index = -2;
            SmartArray testSmartArray = new SmartArray(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(index, 2);
        }
    }
}