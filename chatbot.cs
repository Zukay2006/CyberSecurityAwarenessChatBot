using System;
using System.Media;
using System.Threading;

namespace CyberSecurityBot
{
    class chatbot
    {
        static Random random = new Random(); //for the chatbot to give different responses not the same response over and over again

        public void Start()
        {
            Console.Clear();

            SlideInChatBuddy();
            PlayVoiceGreeting();
            SlideOutChatBuddy();

            Console.Clear(); // important clean screen

            ShowHeader();    // show ONCE
            ShowPurpose();   // show AFTER header

            ShowAnimatedTitle();

            Thread.Sleep(800);

            string userName = AskUserName();

            ChatBuddyConversation(userName);
        }

        // ================= INPUT HELPER =================
        static string ReadUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ResetColor();

            if (input != null && input.Trim().ToLower() == "exit")
            {
                Environment.Exit(0); // immediately stops program
            }

            return string.IsNullOrWhiteSpace(input) ? "" : input;
        }
        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("welcome.wav");
                player.PlaySync();
            }
            catch (Exception)
            {
                Console.WriteLine("Voice greeting could not be played.");
            }
        }

        // ================= HEADER =================
        static void ShowHeader()
        {
            string[] wavingBot =
            { // this is the logo for the chatbot
        "   (^_^)/    ",
        "    /|       ",
        "   / |       ",
        "    / \\      ",
        "  chatbuddy logo "
    };

            string[] text =
            {
        "==============================================",
        "      CYBERSECURITY AWARENESS BOT",
        "=============================================="
    };

            int maxLines = Math.Max(wavingBot.Length, text.Length);

            for (int i = 0; i < maxLines; i++)
            {
                // Orange logo for the logo to stand out
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string left = i < wavingBot.Length ? wavingBot[i] : "               ";
                Console.Write(left + "   ");

                // Green header to be different from the logo
                Console.ForegroundColor = ConsoleColor.Green;
                string right = i < text.Length ? text[i] : "";
                Console.WriteLine(right);
            }

            Console.ResetColor();
            Console.WriteLine();
        }
        static void SlideInChatBuddy()
        {
            string[] bot =
            {
                " [---] ",
                " (o o) ",
                " / | \\ ",
                "  / \\  "
            };

            for (int pos = 0; pos <= 20; pos++)
            {
                Console.Clear();
                ShowHeader();

                foreach (string line in bot)
                    Console.WriteLine(new string(' ', pos) + line);

                Thread.Sleep(50);
            }
        }

        static void SlideOutChatBuddy()
        {
            string[] bot =
            {
                " [---] ",
                " (o o) ",
                " / | \\ ",
                "  / \\  "
            };

            for (int pos = 20; pos >= 0; pos--)
            {
                Console.Clear();
                ShowHeader();

                foreach (string line in bot)
                    Console.WriteLine(new string(' ', pos) + line);

                Thread.Sleep(50);
            }

            Console.Clear();
            ShowHeader();
        }

        static void ShowAnimatedTitle()
        {
            string title = "CYBERSECURITY AWARENESS ASSISTANT";

            ConsoleColor[] colors =
            {
                ConsoleColor.Blue,
                ConsoleColor.Cyan,
                ConsoleColor.White
            };

            for (int i = 0; i < title.Length; i++)
            {
                Console.ForegroundColor = colors[i % colors.Length];
                Console.Write(title[i]);
                Thread.Sleep(80);
            }

            Console.ResetColor();
            Console.WriteLine("\n");
        }

        // ================= Purpose Intro =================
        static void ShowPurpose()
        {
            Console.WriteLine(); // spacing before

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("My purpose is to enhance your knowledge of cybersecurity and help you stay safe online.");
            Console.WriteLine("I will guide you in identifying threats such as phishing attempts and suspicious links,");
            Console.WriteLine("and I will also help you create strong and secure passwords to protect your accounts from hackers.");
            Console.WriteLine("With that being said, BUCKLE UP!");

            Console.ResetColor();

            Console.WriteLine(); // spacing after
        }
            
                static string AskUserName()
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.Write("Please enter your name to start: ");
                        string name = ReadUserInput();

                        if (string.IsNullOrWhiteSpace(name))
                            Console.WriteLine("Invalid input. Please enter a valid name.");
                        else
                            return name;
                    }
                }
            
        
        
        static string GetSarcasticResponse()
        {
            string[] responses =
            { //different responses the chatbot gives when you ask the chatbot how they are feeling
                "Of course I'm always okay",
                "ChatBuddy is always functioning at 100%",
                "Still alive and avoiding cyber criminals",
                "I'm fabulous as always, thanks for asking",
                "Could not be better, unlike phishing scammers"
            };

            return responses[random.Next(responses.Length)];
        }

        // ================= MAIN CHAT =================
        static void ChatBuddyConversation(string userName)
        {
            Console.WriteLine("\nNice meeting you, " + userName + "! How are you today?");
            ReadUserInput();

            Console.WriteLine(GetSarcasticResponse());
            Thread.Sleep(1200);

            Console.WriteLine("\nWhat would you like to learn about today?");
            string topic = ReadUserInput().ToLower();

            AnswerQuestion(topic);

            while (true)
            {
                Console.WriteLine("\nAsk me more questions or type 'exit' to quit:");
                string question = ReadUserInput().ToLower();

                if (string.IsNullOrWhiteSpace(question))
                {
                    Console.WriteLine("Please type a topic.");
                    continue;
                }

                if (question == "exit") // exit the program if you done talking to the chatbot
                {
                    Console.WriteLine("\nGoodbye bestie stay safe online.");
                    break;
                }

                AnswerQuestion(question);
            }
        }

        // ================= PHISHING =================
        static void TeachPhishing()
        {
           

            Console.WriteLine("\nPhishing is a cyberattack where scammers trick you into giving personal information.");

            if (AskToContinueOrQuestion("Would you like a detailed explanation?"))
            {
                Console.WriteLine("Phishing happens via emails, SMS, fake websites, and social media.");
                Console.WriteLine("Scammers often impersonate banks, stores, or delivery companies.");
                Console.WriteLine("Their goal is to steal passwords, OTPs, and banking details.");
            }

            if (AskToContinueOrQuestion("Would you like examples?"))
            {
                Console.WriteLine("- Fake bank emails");
                Console.WriteLine("- Prize scam messages");
                Console.WriteLine("- Fake login pages");
                Console.WriteLine("- SMS links");
            }

            if (AskToContinueOrQuestion("Would you like safety tips?"))
            {
                Console.WriteLine("- Never click suspicious links");
                Console.WriteLine("- Verify the sender");
                Console.WriteLine("- Never share OTPs");
                Console.WriteLine("-Verify websites before logging in");
            }
        }

        // ================= PASSWORDS =================
        static void TeachPasswords()
        {
           

            Console.WriteLine("\nPasswords protect your accounts from hackers and act as a the first line defense for your accounts.");
            Console.WriteLine("A strong password helps protect your personal information,");
            Console.WriteLine("social media accounts, emails, and banking details from hackers");
            if (AskToContinueOrQuestion("Would you like a detailed explanation?"))
            {
                Console.WriteLine("A strong password should include the following:");
                Console.WriteLine("- Use 8 to 12 characters");
                Console.WriteLine("- Mix uppercase letters(A-Z)");
                Console.WriteLine("- Lowercase letters (a-z)");
                Console.WriteLine("- Use numbers (0-9)");
                Console.WriteLine("Special characters such as ! @ # $ % ^ & *");

                Console.WriteLine("Avoid using obvious information such as:");
                Console.WriteLine("-Your name");
                Console.WriteLine("-Your surname");
                Console.WriteLine("-Your date of birth");
                Console.WriteLine("-Your phone number");
                Console.WriteLine("-Common words like 'password' or '123456789'");
            }

            if (AskToContinueOrQuestion("Would you like password examples?"))
            {
                Console.WriteLine("Example of weak passwords:");
                Console.WriteLine("- Weak: 123456");
                Console.WriteLine("-password");
                Console.WriteLine("-2468");
                Console.WriteLine("-qwerty");

                Console.WriteLine("Example of strong passwords");

                Console.WriteLine("- Strong: Z@ku#2026Safe!");
                Console.WriteLine("-CyberLine@88#");
                Console.WriteLine("-StaySafe@Net11");
            }

            if (AskToContinueOrQuestion("Would you like password safety tips?"))
            {
                Console.WriteLine("- Never share passwords");
                Console.WriteLine("- Use different passwords");
                Console.WriteLine("- Enable 2FA");
                Console.WriteLine("-Change your password regulary");
                Console.WriteLine("-Use different password for social media, email as well as bamking");
                Console.WriteLine("-Avoid sending password on public computers");
            }

            if (AskToContinueOrQuestion("Would you like to learn why password safety is important?"))
            {
                Console.WriteLine("\nIf hackers guess your password, they can:");
                Console.WriteLine("- Access your accounts");
                Console.WriteLine("- Steal personal information");
                Console.WriteLine("- Scam your contacts");
                Console.WriteLine("- Lock you out of your own accounts");
                Console.WriteLine("- Commit identity theft");
            }
        }


        // ================= LINKS =================
        static void TeachLinks()
        {
            Console.WriteLine("\n SUSPICIOUS LINKS INFORMATION");
            Console.WriteLine("Suspicious links are one of the most common ways cybercriminals try to steal personal information.");

            if (AskToContinueOrQuestion("Would you like a detailed explanation?"))
            {
                Console.WriteLine("\nDetailed explanation:");
                Console.WriteLine("- Fake links are designed to look like trusted websites.");
                Console.WriteLine("- Hackers often change one or two letters to trick users.");
                Console.WriteLine("- Example: facebo0k.com instead of facebook.com");
                Console.WriteLine("- They may also use urgent messages to pressure you into clicking.");
                Console.WriteLine("- These links can lead to fake login pages, malware downloads, or scam websites.");
            }

            if (AskToContinueOrQuestion("Would you like examples of suspicious links?"))
            {
                Console.WriteLine("\nExamples:");
                Console.WriteLine("- bank-alert-update.co");
                Console.WriteLine("- paypaI-login-security.com");
                Console.WriteLine("- facebo0k-account-check.net");
                Console.WriteLine("- free-prize-click-now.com");
            }

            if (AskToContinueOrQuestion("Would you like safety tips?"))
            {
                Console.WriteLine("\nSafety tips:");
                Console.WriteLine("- Hover your mouse over the link before clicking.");
                Console.WriteLine("- Check if the website starts with https://");
                Console.WriteLine("- Look carefully for spelling mistakes.");
                Console.WriteLine("- Avoid links from unknown numbers or email addresses.");
                Console.WriteLine("- Never click links that create panic like 'Your account will be locked now!'");
            }

            if (AskToContinueOrQuestion("Would you like to know what hackers use suspicious links for?"))
            {
                Console.WriteLine("\nHackers use suspicious links to:");
                Console.WriteLine("- Steal usernames and passwords");
                Console.WriteLine("- Install viruses or malware");
                Console.WriteLine("- Access banking details");
                Console.WriteLine("- Trick users into downloading harmful files");
            }
        }
        //=================Ask To Continue section=====================
        static bool AskToContinueOrQuestion(string message)
        {
            Console.WriteLine("\n" + message);
            string response = ReadUserInput().ToLower();

            // If user wants more
            if (response.Contains("yes") ||
                response.Contains("more") ||
                response.Contains("continue") ||
                response.Contains("sure") ||
                response.Contains("okay"))
            {
                return true;
            }

            // If user does not want more
            if (response.Contains("no") ||
                response.Contains("stop") ||
                response.Contains("skip"))
            {
                return false;
            }

            // If user asks another topic
            if (response.Contains("password") ||
                response.Contains("phish") ||
                response.Contains("scam") ||
                response.Contains("link"))
            {
                AnswerQuestion(response);
                return false;
            }

            // Unknown topic
            Console.WriteLine("I didn't understand that response.");

            return false;

            if (response == "exit")
            {
                Environment.Exit(0);
            }
        }
        // ================= ANSWER ENGINE =================
        static void AnswerQuestion(string question)
        {
            if (question.Contains("password"))
                TeachPasswords();
            else if (question.Contains("phish") || question.Contains("scam"))
                TeachPhishing();
            else if (question.Contains("link"))
                TeachLinks();
            else
                Console.WriteLine("I didn’t quite understand that. Please mention phishing, passwords, or links.");
        }
    }
}