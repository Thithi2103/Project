using System;
using System.Collections.Generic;
using BL;
using Persistence;

public class Menu {
    User userOnline;
    public Menu () {
        AppBl = new ApplicationBL ();
        UserBl = new UserBL ();
        PaymentBl = new PaymentBL();
        BillBl = new BillBL ();
        existProgram = false;
    }
    ApplicationBL AppBl;
    UserBL UserBl;
    PaymentBL PaymentBl;
    BillBL BillBl;
    bool existProgram;
    public void MainMenu () {
        while (true) {
            bool isExit = false;
            string line = "----------------------------------------------------------------------------";
            string line1 = "------------------------------------------------------------------┌---------";
            string line3 = "------------------------------------------------------------------└---------";
            string title = "Ⓜ Ⓐ Ⓡ Ⓚ Ⓔ Ⓣ  Ⓢ Ⓣ Ⓞ Ⓡ Ⓔ";
            string title1 = "Login";
            string title2 = "Exit";
            int lengthLine = line.Length + 2;
            int position = lengthLine / 2 + title.Length / 2 - 1;
            int position2 = lengthLine / 2 + title.Length / 2 - 1;
            Console.Clear ();
            Console.WriteLine(" ┌{0}┐", line);
            Console.WriteLine(" │{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
            Console.WriteLine(" ┌{0}┐", line1);
            Console.WriteLine(" │{0}{1," + (lengthLine - position2 + 43) + "}", title1, "|    1    │");
            Console.WriteLine(" ┌{0}┐", line1);
            Console.WriteLine(" │{0}{1," + (lengthLine - position2 + 44) + "}", title2, "|    0    │");
            Console.WriteLine(" └{0}┘", line3);
            Console.Write ("\n   Choice...");
            string Choice = Console.ReadLine ();
            switch (Choice) {
                case "1":
                    Login ();
                    break;
                case "0":
                    isExit = true;
                    break;
            }
            if (isExit == true || existProgram == true) break;
        }
    }
    void Login () {
        string username = "";
        string password = "";
        while (true) {
            string p = "";
            string line = "--------------------------------------------------------";

            while (true) {
                int lengthP = p.Length;
                string title = "Login...";
                int lengthLine = line.Length + 2;
                int position = lengthLine / 2 + title.Length / 2 - 1;
                ConsoleKeyInfo key;
                Console.Clear ();
                Console.WriteLine(" ┌{0}┐", line);
                Console.WriteLine(" │{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
                Console.WriteLine(" ┌{0}┐", line);
                if (username.Length == 0) {
                    Console.Write ("  * Username: ");
                    username = Console.ReadLine ();
                } else {
                    Console.WriteLine ("  * Username: " + username);
                }
                if (password.Length == 0) {
                    Console.Write ("  * Password: " + new string ('*', p.Length));
                    key = Console.ReadKey ();
                    if (key.Key == ConsoleKey.Enter) {
                        password = p;
                        break;
                    } else if (key.Key == ConsoleKey.Backspace) {
                        if (p.Length != 0)
                            p = p.Remove (p.Length - 1);
                    } else p += key.KeyChar;
                } else {
                    break;
                }
            }
            Console.WriteLine ("  * Password: " + new string ('*', password.Length));
            Console.WriteLine(" └{0}┘", line);
            Console.WriteLine(new string (' ', 8) + " ┌---------------------------------------┐");
            Console.WriteLine(new string (' ', 8) + " |               1. Login                |");
            Console.WriteLine(new string (' ', 8) + " └---------------------------------------┘");
            Console.WriteLine(new string (' ', 8) + " ┌---------------------------------------┐");
            Console.WriteLine(new string (' ', 8) + " |               0. Quit                 |");
            Console.WriteLine(new string (' ', 8) + " └---------------------------------------┘");
            Console.Write("\n  Choice...");
            string choice = Console.ReadLine ();
            if (choice == "1") {
                try
                {
                    if (UserBl.CheckExistUserAndPass (username, password)) {
                        userOnline = UserBl.GetUserByUserName(username);
                        SystemGUI ();
                    } else {
                        Console.Clear ();
                        Console.Write ("\nIncorrect Username or password!\n\nPress anykey to countinue...");
                        Console.ReadKey ();
                    }
                }catch
                {
                    Console.Clear ();
                    Console.Write ("\nIncorrect Username or password!\n\nPress anykey to countinue...");
                    Console.ReadKey ();
                }
                break;
            } else if (choice == "0")
                break;
        }
    }
    void SystemGUI () {
        while (true) {
            bool isExit = false;
            string line = "----------------------------------------------------------------------------";
            string line1 = "------------------------------------------------------------------┌---------";
            string line3 = "------------------------------------------------------------------└---------"; 
            string title = "Ⓜ Ⓐ Ⓡ Ⓚ Ⓔ Ⓣ  Ⓢ Ⓣ Ⓞ Ⓡ Ⓔ";
            string title1 = "Search Application";
            string title2 = "My Appliction";
            string title3 = "History Trade";
            string title4 = "Log out";
            string title5 = "Exit";
            int lengthLine = line.Length + 2;
            int position = lengthLine / 2 + title.Length / 2 - 1;
            int position2 = lengthLine / 2 + title.Length / 2 - 1;
            Console.Clear ();
            Console.WriteLine(" ┌{0}┐", line);
            Console.WriteLine(" │{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
            Console.WriteLine(" └{0}┘", line1);
            Console.WriteLine(" │{0}{1," + (lengthLine - position2 + 30) + "}", title1, "|    1    │");
            Console.WriteLine(" ┌{0}┐", line1);
            Console.WriteLine(" │{0}{1," + (lengthLine - position2 + 35) + "}", title2, "|    2    │");
            Console.WriteLine(" ┌{0}┐", line1);
            Console.WriteLine(" │{0}{1," + (lengthLine - position2 + 35) + "}", title3, "|    3    │");
            Console.WriteLine(" ┌{0}┐", line1); 
            Console.WriteLine(" │{0}{1," + (lengthLine - position2 + 41) + "}", title4, "|    4    │");
            Console.WriteLine(" ┌{0}┐", line1);
            Console.WriteLine(" │{0}{1," + (lengthLine - position2 + 44) + "}", title5, "|    0    │");
            Console.WriteLine(" └{0}┘", line3);
            Console.Write ("\n   Choice...");
            string choice = Console.ReadLine ();
            switch (choice) {
                case "1": case "/search":
                    Search ();
                    break;
                case "/my_app": case "2" :
                    DisplayMyApplications ();
                    break;
                case "3": case "/history_trade":
                    DisplayHistoryTrade ();
                    break;
                case "/log_out": case "4":
                    isExit = true;
                    userOnline = null;
                    break;
                case "0": case "/exit":
                    isExit = true;
                    existProgram = true;
                    break;
            }
            if (isExit) break;
        }
    }
    void Search () {
        while (true) {
            bool isExit = false;
            string nameapp = "";
            ConsoleKeyInfo key;
            List<Application> listApp = new List<Application>();
            while (true) {
                string line = "----------------------------------------------------------------------------";
                string title = "SEARCH APPLICATION";
                int lengthLine = line.Length + 2;
                int position = lengthLine / 2 + title.Length / 2 - 1;
                Console.Clear ();
                Console.WriteLine("┌{0}┐", line);
                Console.WriteLine("|{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
                Console.WriteLine("├{0}┤", line);
                Console.Write ("  Games, Apps and More: ");
                Console.WriteLine (nameapp);
                Console.WriteLine("└{0}┘\n", line);
                if(nameapp != "" && nameapp.Trim() != "")
                {
                    listApp = AppBl.SearchApplicationByName(nameapp);
                    if(listApp.Count > 0)
                    foreach(var x in listApp)
                    {
                        Console.WriteLine(x.Name);
                    }
                }
                Console.SetCursorPosition(24 + nameapp.Length, 1);
                key = Console.ReadKey ();
                if (key.Key == ConsoleKey.Escape) {
                    isExit = true;
                    break;
                } else if (key.Key == ConsoleKey.Enter) {
                    if(listApp.Count <= 0)
                    {
                        Console.Write("Not found!");
                    }
                    else if(listApp.Count == 1)
                    {
                        DisplayAnApp(listApp[0]);
                        break;
                    }
                    else
                    {
                        DisplayListApp(listApp);
                        break;
                    }
                    
                } else if (key.Key == ConsoleKey.Backspace) {
                    if(nameapp.Length > 0)
                    nameapp = nameapp.Remove (nameapp.Length - 1);
                } else nameapp += key.KeyChar;
            }
            if (isExit == true) break;
        }
    }
    void DisplayListApp (List<Application> listApp) {
        while (true) {
            int ichoice;
            Console.Clear ();
            int i = 1;
            foreach (var x in listApp) {
                Console.WriteLine ($"{i++}.{x.Name}");
            }
            Console.WriteLine(" ┌------------┐");
            Console.WriteLine(" |0.  Return  |");
            Console.WriteLine(" └------------┘");
            Console.Write ("\n#Choice: ");
            string schoice = Console.ReadLine ();
            if (int.TryParse (schoice, out ichoice)) {
                if(ichoice == 0)
                    break;
                else if (ichoice >= 1 && ichoice <= listApp.Count) {
                    DisplayAnApp (listApp[ichoice - 1]);
                    break;
                }
            }
        }

    }
    void DisplayAnApp (Application app) {
        while (true) {
            bool isExit = false;
            bool isOwn = false;
            string size;
            string line = "--------------------------------------------------------------------------";
            int lengthLine = line.Length + 2;
            int position = lengthLine / 2 + app.Name.Length / 2 - 1;
            Console.Clear ();
            Console.WriteLine("┌{0}┐", line);
            Console.WriteLine("│{0," + position + "}{1," + (lengthLine - position - 1) + "}", app.Name, "│");
            Console.WriteLine("├{0}┤", line);
            Console.WriteLine("│{0," + (lengthLine - 1) + "}", "│");
            Console.WriteLine("| Kind:          {0}{1," + (lengthLine - 17 - app.Kind.Length) + "}", app.Kind, "|");
            Console.WriteLine("| Ratings:       {0}{1," + (lengthLine - 17 - app.Rating.Length) + "}", app.Rating, "|");
            Console.WriteLine("| Description:   {0}{1," + (lengthLine - 17 - app.Description.Length) + "}", app.Description, "|");
            Console.WriteLine("| Publisher:     {0}{1," + (lengthLine - 17 - app.Publisher.Length) + "}", app.Publisher, "|");
            Console.WriteLine($"| DatePublish:   {app.DatePublisher.Date.Day+"/"+app.DatePublisher.Date.Month+"/"+app.DatePublisher.Date.Year+ new string(' ', 49)}|");
            string price = app.Price.ToString("N0") + "VND";
            Console.WriteLine("| Price:         {0}{1," + (lengthLine - 17 - price.Length) + "}", price, "|");
            if(app.Size >= 100)size = (app.Size / 1000).ToString() + " GB";
            else size = app.Size.ToString() + " MB";
            Console.WriteLine("| Size:          {0}{1," + (lengthLine - 17 - size.Length) + "}", size, "|");
            Console.WriteLine("└{0}┘\n", line);
            if(UserBl.GetApplicationBoughtByUserID(userOnline.User_ID).Contains(app))
            {
                Console.WriteLine(" This Application has OWNER!\n");
                isOwn = true;
            }
            else
            {
                Console.WriteLine(new string(' ', 26) + " ┌---------------------┐");
                Console.WriteLine(new string(' ', 26) + " |      1. Buy         |");
                Console.WriteLine(new string(' ', 26) + " └---------------------┘");
            }
                Console.WriteLine(new string(' ', 26) + " ┌---------------------┐");
                Console.WriteLine(new string(' ', 26) + " |      0. Return      |");
                Console.WriteLine(new string(' ', 26) + " └---------------------┘");
                Console.Write(" #Choice: ");
            string choice = Console.ReadLine();
            if(choice == "1" && isOwn == false)
            {
                BuyApp(app);
            }
            else if(choice == "0")
                isExit = true;
            if(isExit)break;
        }
    }
    void BuyApp(Application app)
    {
        while(true)
        {
            bool isExit = false;
            int ichoice;
            string line = "-------------------------------------------------------------------------";
            string title = "Buy Application";
            int lengthLine = line.Length + 2;
            int position = lengthLine / 2 + title.Length / 2 - 1;
            Console.Clear();
            Console.WriteLine("┌{0}┐", line);
            Console.WriteLine("│{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
            Console.WriteLine("├{0}┤", line);
            Console.WriteLine("│{0," + (lengthLine - 1) + "}", "│");
            Console.WriteLine("| Application Name:  {0}{1," + (lengthLine - 21 - app.Name.Length) + "}", app.Name, "|");
            string price = app.Price.ToString("N0") + "VND";
            Console.WriteLine("| Price:  {0}{1," + (lengthLine - 10 - price.Length) + "}", price, "|");
            Console.WriteLine("└{0}┘", line);
            Console.WriteLine(" Payment Method:\n");
            userOnline.ListPayment = PaymentBl.GetPayments(userOnline.User_ID);
            for(int i = 0; i < userOnline.ListPayment.Count; i++)
            {
                int p = i + 1;
                Console.WriteLine( new string(' ', 29) + p + ". " + userOnline.ListPayment[i].Name + "\n");
            }

                Console.WriteLine(new string(' ', 25) + " ┌---------------------┐");
                Console.WriteLine(new string(' ', 25) + " |     0. Return       |");
                Console.WriteLine(new string(' ', 25) + " └---------------------┘");
            Console.Write(" Choice... ");
            string schoice = Console.ReadLine();
            if(schoice == "0")
                isExit = true;
            else if(int.TryParse(schoice, out ichoice))
            {
                if(ichoice >= 1 && ichoice <= userOnline.ListPayment.Count)
                {
                    Console.Clear();
                    if(userOnline.ListPayment[ichoice-1].Name == "By Store")
                    {
                        if(PaymentBl.CheckPayment(userOnline.ListPayment[ichoice-1], app.Price))
                        {
                            Console.Write(" We are checkking payment account...");
                            Bill bill = new Bill()
                            {
                                App = app,
                                User = userOnline,
                                Payment = userOnline.ListPayment[ichoice-1],
                                UnitPrice = app.Price
                            };
                            try
                            {
                                bool checkCreate = BillBl.CreateBill(bill);
                                if(checkCreate)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Buy {app.Name} !\nSuccessful\n\nPress anykey to return...");
                                    Console.ReadKey();
                                    isExit = true;
                                }
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Not Successful\n\nPress anykey to return...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Not Successful\n\nPress anykey to return...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("This payment havent been updated!\n\nPress anykey to return...");
                        Console.ReadKey();
                    }
                }
            }

            if(isExit == true)break;
        }
    }
    void DisplayMyApplications () {
        while(true)
        {
            string line = "---------------------------------------------------";
            string title = "App Bounght";
            int lengthLine = line.Length + 2;
            int position = lengthLine / 2 + title.Length / 2 - 1;
            Console.Clear ();
            Console.WriteLine("┌{0}┐", line);
            Console.WriteLine("│{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
            Console.WriteLine("├{0}┤", line);
            List<Application> listApp = UserBl.GetApplicationBoughtByUserID(userOnline.User_ID);
            int i = 1;
            foreach(var x in listApp)
            {
                Console.WriteLine("│   {0}{1}{2," + (lengthLine - 7 - x.Name.Length) + "}",i + ". ", x.Name, "│");
                i++;
            }
            Console.WriteLine("└{0}┘", line);
            
                Console.WriteLine(new string(' ', 15) + " ┌---------------------┐");
                Console.WriteLine(new string(' ', 15) + " |      0. Return      |");
                Console.WriteLine(new string(' ', 15) + " └---------------------┘");
            Console.Write("\n  Choice... ");
            string choice = Console.ReadLine();
            int ichoice;
            string size;
            if(int.TryParse(choice, out ichoice))
            {
                if(ichoice == 0)break;
                if(ichoice <= listApp.Count)
                {
                    Console.Clear ();
                    Console.WriteLine ($"Application Name : {listApp[ichoice-1].Name}");
                    Console.WriteLine ($"Kind             : {listApp[ichoice-1].Kind}");
                    Console.WriteLine ($"Description      : {listApp[ichoice-1].Description}");
                    Console.WriteLine ($"Publisher        : {listApp[ichoice-1].Publisher}");
                    Console.WriteLine ($"DatePublish      : {listApp[ichoice-1].DatePublisher.Date.Day+"/"+listApp[ichoice-1].DatePublisher.Date.Month+"/"+listApp[ichoice-1].DatePublisher.Date.Year}");
                    Console.WriteLine ($"Price            : {listApp[ichoice-1].Price} VND");
                    if(listApp[ichoice-1].Size >= 100)size = (listApp[ichoice-1].Size / 1000).ToString() + " GB";
                     else size = listApp[ichoice-1].Size.ToString() + " MB";
                     Console.WriteLine ($"Size             : {size}");
                }
                Console.Write("\n Press anykey to return...");
                Console.ReadKey();
            }
        }
    }
    void DisplayHistoryTrade () {
        string line = "--------┐---------------------┐--------------┐-------------------------";
        string end = "-----------------------------------------------------------------------"; 
        string end2 = "--------┘---------------------┘--------------┘-------------------------";
        string title = "History Trade";
        int lengthLine = line.Length + 2;
        int position = lengthLine / 2 + title.Length / 2 - 1;
        Console.Clear ();
        Console.WriteLine("┌{0}┐", end);
        Console.WriteLine("│{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
        Console.WriteLine("├{0}┤", line);
        List<Bill> listBill = BillBl.GetListBillByUserID(userOnline.User_ID);
        Console.WriteLine("|BillID  |Appliction           |Price         |Date                     |");
        Console.WriteLine("└{0}┘", end2);
        foreach(var x in listBill)
        {
            string print = "|" + new string (' ', 1) + x.Bill_ID + new string(' ',7 - x.Bill_ID.ToString().Length) + 
                           "|" + x.App.Name + new string(' ', 21 - x.App.Name.ToString().Length) + 
                           "|" + x.UnitPrice.ToString("N0") + " VND" + new string(' ', 9 - x.UnitPrice.ToString().Length) + 
                           "|" +x.DateCreate.Day + "/" + x.DateCreate.Month + "/" + x.DateCreate.Year + "                |";
            Console.WriteLine(print);
        }
        Console.WriteLine("└{0}┘", end2);
        Console.Write("\nPress anykey to return ...");
        Console.ReadKey();
    }

    public static List<string> LineFormat(string data, int lengthLine)
        {
            List<string> lines = new List<string>();
            int startIndex = 0, startIndexFind = 0;
            int lastIndex = lengthLine, lengthString = 0;
            int index, preIndex;
            for (int i = 0; lengthString < data.Length; i++)
            {
                index = 0;
                do
                {
                    preIndex = index;
                    index = data.IndexOf(" ", startIndexFind);
                    startIndexFind = index + 1;
                } while (index < lastIndex && index != -1);
                if (preIndex == 0)
                {
                    if (index == -1 || index > lastIndex && data.Length - lengthString > lengthLine)
                    {
                        preIndex = startIndex + lengthLine;
                    }
                    if (data.Length - lengthString <= lengthLine)
                    {
                        preIndex = data.Length;
                    }
                }
                int length = preIndex - startIndex;
                lines.Add(data.Substring(startIndex, length));
                lengthString += lines[i].Length;
                lines[i] = lines[i].Trim();
                lastIndex = startIndex + lengthLine;
                startIndex = preIndex;
                startIndexFind = lengthString + 1;
            }
            return lines;
        }


      
    
}