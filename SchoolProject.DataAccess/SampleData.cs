using SchoolProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolProject.DataAccess
{
    public static class SampleData {
        public static void Initial(SchoolProjectDBContext context)
        {

            if (!context.ClassNumbs.Any())
                context.ClassNumbs.AddRange(ClassNumbs.Select(c => c.Value));

            if (!context.Students.Any()) {
                context.AddRange(
                new Student
                {
                    firstName = "Максим",
                    lastName = "Привалов",
                    photo = "/img/Boy-03.jpg",
                    avgScore = 5,
                    homeAddress = "ул. Счастливая, 5-11",
                    classNumb = ClassNumbs["4а"]
                },
                new Student
                {
                    firstName = "Филип",
                    lastName = "Кудрин",
                    photo = "/img/Boy-01.jpg",
                    avgScore = 3,
                    homeAddress = "ул. Стойкости, 1-6",
                    classNumb = ClassNumbs["4а"]
                },
               new Student
               {
                   firstName = "Маргарита",
                   lastName = "Куваева",
                   photo = "/img/Girl-01.jpg",
                   avgScore = 4,
                   homeAddress = "ул. Цветочная, 10-25",
                   classNumb = ClassNumbs["4а"]
               },
               new Student
               {
                   firstName = "Василий",
                   lastName = "Пупкин",
                   photo = "/img/Boy-04.jpg",
                   avgScore = 2,
                   homeAddress = "ул. Победы, 7-36",
                   classNumb = ClassNumbs["4б"]
               },
               new Student
               {
                   firstName = "Юрий",
                   lastName = "Коротков",
                   photo = "/img/Boy-05.jpg",
                   avgScore = 4,
                   homeAddress = "ул. Первомайская, 12-76",
                   classNumb = ClassNumbs["4б"]
               },
               new Student
               {
                   firstName = "Ангелина",
                   lastName = "Сидорова",
                   photo = "/img/Girl-02.jpg",
                   avgScore = 3,
                   homeAddress = "ул. Нижняя, 3-5",
                   classNumb = ClassNumbs["4б"]
               },
               new Student
               {
                   firstName = "Кристина",
                   lastName = "Круглова",
                   photo = "/img/Girl-03.jpg",
                   avgScore = 5,
                   homeAddress = "ул. Верхняя, 20-111",
                   classNumb = ClassNumbs["4и"]
               },
               new Student
               {
                   firstName = "Иван",
                   lastName = "Петров",
                   photo = "/img/Boy-02.jpg",
                   avgScore = 3,
                   homeAddress = "ул. Счастливая, 7-13",
                   classNumb = ClassNumbs["4и"]
                }
                );
            }
            context.SaveChanges();
    }

    private static Dictionary<string, ClassNumb> classNumb;
    public static Dictionary<string, ClassNumb> ClassNumbs
    {
        get
        {
            if (classNumb == null)
            {
                var list = new ClassNumb[] {
                        new ClassNumb { classNumb = "1а", desc = "Начальное образование" },
                    new ClassNumb { classNumb = "4а", desc = "Физико-математический" },
                    new ClassNumb { classNumb = "4б", desc = "Химико-биологический" },
                    new ClassNumb { classNumb = "4и", desc = "Культура и искусство" },
                    new ClassNumb { classNumb = "10а", desc = "Старшая школа" }
                    };
                classNumb = new Dictionary<string, ClassNumb>();
                foreach (ClassNumb el in list)
                    classNumb.Add(el.classNumb, el);
            }
            return classNumb;
        }
    }
}
}