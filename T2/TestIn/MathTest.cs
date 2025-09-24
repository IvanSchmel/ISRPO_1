using T2;
namespace TestIn
{
    [TestClass]
    public class MathTest
    {
        private CrossLines a;
        private CrossLines b;
        string s;
        (double, double) point;
        [TestMethod]
        public void SameLines() // одинаковые отрезки
        {
            a = new CrossLines(0, 0, 1, 1);
            b = new CrossLines(0, 0, 1, 1);
            
            Assert.IsTrue(!a.Intersection(a,b,out point,ref s));
        }
        [TestMethod]
        public void OppositeLines() // противоположные отрезки
        {
            a = new CrossLines(0, 0, 1, 1);
            b = new CrossLines(1, 1, 0, 0);
            Assert.IsTrue(!a.Intersection(a, b, out point, ref s));
        }
        [TestMethod]
        public void JustTest() // обычные координаты
        {
            a = new CrossLines(4, 1, 5, 6);
            b = new CrossLines(2, 2, 7, 3);
            Assert.IsTrue(a.Intersection(a, b, out point, ref s));
        }
        [TestMethod]
        public void NotInter() // не пересекаются
        {
            a = new CrossLines(3, 3, 7, 6);
            b = new CrossLines(5, 4, 10, 5);
            Assert.IsTrue(!a.Intersection(a, b, out point, ref s));
        }
    }
    [TestClass]
    public class MathTest2
    {
        private CrossLines a;
        private CrossLines b;
        private double angle;
        [TestMethod]
        public void Test1()
        {
            a = new CrossLines(4, 1, 5, 6);
            b = new CrossLines(2, 2, 7, 3);
            a.Angle(a, b, out angle);
            Assert.AreNotEqual(0, angle);
        }
        public void Test2()
        {
            a = new CrossLines(0, 0, 4, 0);
            b = new CrossLines(0, 0, 4, 4);
            a.Angle(a, b, out angle);
            Assert.AreEqual(90, angle);
        }
        public void Test3()
        {
            a = new CrossLines(0, 0, 2, 0);
            b = new CrossLines(0, 0, 2, 1);
            a.Angle(a, b, out angle);
            Assert.AreEqual(90, angle);
        }
    }
}