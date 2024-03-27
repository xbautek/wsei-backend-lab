using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;

public static class SeedData
{
    public static void Seed(this WebApplication app)
    {

        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();

            
            var quiz1Items = new List<QuizItem>
            {
                new QuizItem(1, "What color is grass", new List<string>{"blue","pink","purple"}, "green"),
                new QuizItem(2, "What color is monkey", new List<string>{"pink","brown","red"}, "black"),
                new QuizItem(3, "What color is lemon", new List<string>{"red","green","grey"}, "yellow")
            };
            var quiz2Items = new List<QuizItem>
            {
                new QuizItem(1, "Baptism of poland year", new List<string>{"123","321","333"}, "966"),
                new QuizItem(2, "WW2 year", new List<string>{"1932","2323","1111"}, "1939"),
                new QuizItem(3, "grunwald war year", new List<string>{"1234","1111","1000"}, "1410")
            };
            
            var quiz1 = new Quiz(1, quiz1Items, "Quiz 1");
            var quiz2 = new Quiz(2, quiz2Items, "Quiz 2");

            if (quizRepo != null)
            {
                quizRepo.Add(quiz1);
                quizRepo.Add(quiz2);
            }
        } 
    }
}


