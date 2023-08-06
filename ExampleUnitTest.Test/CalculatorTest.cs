using ExampleUnitTest.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExampleUnitTest.Test
{
    public class CalculatorTest
    {
        public Calculator calculator { get; set; }
        public CalculatorTest()
        {
            this.calculator = new Calculator();
        }

        /// <summary>
        /// Parametre almayan
        /// </summary>
        [Fact]
        public void AddTest()
        {
            //Arrange
            //değişkenleri initial ettiğimiz yer
            //veya bir nesne örneği oluşturacağımız yer
            int a = 5;
            int b = 10;

            //Act
            //yukarıda initial ettiğimiz classlarımızı parametre olarak gönderip 
            //metotları çağırdığımız yer
            var total = calculator.add(a, b);

            //Assert
            //doğrulama evresidir.
            //Assert içinde Equal ile karşılaştırma yapar.
            Assert.Equal<int>(15, total);

            //Contains => Pass
            //içerisinde olmasını bekleriz
            Assert.Contains("Tolgahan", "Tolgahan ÖZTÜRK");

            //DoesNotContain => Pass 
            //içerisinde olmamasını bekleriz
            Assert.DoesNotContain("Ayhan", "Tolgahan ÖZTÜRK");

            var names = new List<string>
            {
                "Ahmet",
                "Mehmet",
                "Ayşe"
            };

            //alttaki kullanım şekli aynıdır
            Assert.Contains("Ahmet", names);
            Assert.Contains(names, x => x == "Ahmet");

            Assert.DoesNotContain("Ayhan", names);


            Assert.True(3 > 2);

            Assert.False(2 > 3);

            // tiplerini karşılaştırıyorum
            Assert.True("".GetType() == typeof(string));

            //alınan örnek bir regex dog ile başlayan bir ifade bekliyor
            var regEx = "^dog";

            //ilk regex değerimizi verip elde ettiğimizi değeri veriyorum
            Assert.Matches(regEx, "dog lap");

            //aynı şekilde yukarıda tanımladığımız regex değeri
            //verip dönüş değerini lap diye belirtip içinde olmadığını belirtiyorum.
            Assert.DoesNotMatch(regEx, "lap");


            //ilk değer
            Assert.StartsWith("Beypazarı", "Beypazarı doğal maden suyu");

            //son değer
            Assert.EndsWith("suyu", "Beypazarı doğal maden suyu");

            var listString = new List<string>();
            //Empty boş değer
            Assert.Empty(new List<string>());
            //Empty 2.örnek
            Assert.Empty(listString);

            //string değeri dolduralım
            listString.Add("Ayşe");
            //dolu olup olmadığını kontrol ediyoruz
            Assert.NotEmpty(listString);

            //ilki dönen değer diğer 2 değer ise aralığı belirtmiş oluyoruz.
            Assert.InRange(10, 2, 20);

            //ilki dönen değer diğer 2 değer ise aralığı belirtmiş oluyoruz.
            //aralığın dışında olmasını bekler
            Assert.NotInRange(1, 2, 20);

            //Single 1.Örnek
            var oneSingle = new List<string>()
            {
                "Test"
            };

            Assert.Single(oneSingle);

            //Single tip güvenli Örnek

            Assert.Single<string>(oneSingle);


            //bizden bir object istemektedir. Vermiş olduğum object herşey olabilir. Ama vermiş olduğum object
            //bir string tipindeyse geriye true değilse false döner
            //Bu arada object tipi en üst seviyedeki bir tiptir. Diğer bütün tipler object veri tipinden türemiştir.
            Assert.IsType<string>("Beypazarı");

            Assert.IsType<int>(5);

            Assert.IsNotType<int>("Beypazarı");


            var isAssign = new List<string>();

            Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());
            Assert.IsAssignableFrom<IEnumerable<string>>(isAssign);

            Assert.IsAssignableFrom<object>("Beypazarı");
            Assert.IsAssignableFrom<object>(2);

            string name = null;

            Assert.Null(name);
            name = "Ahmet";

            Assert.NotNull(name);

            //generic kullanımı hem performans hem de tip güvenli olur.
            Assert.Equal<int>(2, 2);

            Assert.NotEqual<int>(3, 2);
        }


        /// <summary>
        /// Parametre Alan
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expectedTotal"></param>
        [Theory]
        [InlineData(3,5,8)]
        [InlineData(7,8,15)]
        public void AddTest2(int a, int b, int expectedTotal)
        {
            var actualTotal = calculator.add(a, b);

            Assert.Equal(expectedTotal, actualTotal);
        }



    }
}
