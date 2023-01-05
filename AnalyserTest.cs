using MoodAnalizer;


namespace AnalyzerTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void GivenSadMessage_WhenAnalyze_ShouldReturnSadMood()
        {
            //Arrange
            string message = "I am in sad Mood";
            //Act
            MoodAnalyser analyser = new MoodAnalyser(message);
            string actual = analyser.AnalyzeMood();
            //Assert
            Assert.AreEqual(actual, "Sad");
        }
        [TestMethod]
        public void GivenHappyMessage_WhenAnalyze_ShouldReturnHappyMood()
        {
            //Arrange
            string message = "I am in any Mood";
            //Act
            MoodAnalyser analyser = new MoodAnalyser(message);
            string actual = analyser.AnalyzeMood();
            //Assert
            Assert.AreEqual(actual, "Happy");
        }
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalyserException()
        {
            try
            {
                string message = null;
                MoodAnalyser analyser = new MoodAnalyser(message);
                string mood = analyser.AnalyzeMood();
            }catch(MoodAnalyserException ex)
            {
                Assert.AreEqual("Mood should not null", ex.Message);
            }
        }
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalyserException_Indicating_EmptyMood()
        {
            try
            {
                string message = " ";
                MoodAnalyser analyser = new MoodAnalyser(message);
                string mood = analyser.AnalyzeMood();
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual("Mood should not empty", ex.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_WhenShouldReturnMoodAnalysedObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalizer.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
                
        }
        [TestMethod]
        public void Given_ImproperClassName_WhenShould_Throw_MoodAanalyserException()
        {
            string expected = "Class not found";
            try
            {
                object moodAnalyseObject = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalizer.MoodAnalyser", "MoodAnalyser");
            }
            catch(MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalysedObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser("Happy");
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalizer.MoodAnalyser", "MoodAnalyser", "Happy");
            expected.Equals(obj);
        }
        [TestMethod]
        public void Given_Improper_ClassName_WhenShould_Throw_MoodAanalyserException()
        {
            string expected = "Class not found";
            try
            {
                object moodAnalyserObject = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalizer.MoodAnalyser", "MoodAnalyser", "Class not found");
            }catch(MoodAnalyserException ex)
            {
                Assert.Equals(expected,ex.Message);
            }
        }
        [TestMethod]
        public void Given_Improper_ConstructorName_whenShould_Throw_MoodAanalyserException()
        {
            string expected = "Constructor is not found";
            try
            {
                object moodAnalyserObject = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalizer.MoodAnalyser", "MoodAnalyser", "Constructor is not found");
            }
            catch (MoodAnalyserException ex)
            {
                Assert.Equals(expected, ex.Message);
            }
        }
        [TestMethod]
        public void Given_Happy_Massege_UsingReflection_When_Should_ReturnHappy()
        {
            string expected = "Happy";
            string mood = MoodAnalyzerFactory.InvokeAnalysedMood("Happy", "AnalyzeMood");
            Assert.AreEqual(expected, mood);
             
        }
        [TestMethod]
        public void Given_ImproperMethodName_whenShould_throw_MoodAnalyserException()
        {
            string expected = "Method is not found";
            try
            {
                string mood = MoodAnalyzerFactory.InvokeAnalysedMood("Happy", "DemoMethod");
            }catch(MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        

         
    }
}