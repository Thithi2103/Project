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
// Trưởng
// Trưởng
static void ViewLaptopDetails()
        {
            Console.CursorVisible = true;
            Laptop laptop = new LaptopBL().GetById(GetNumber("ID"));
            if (laptop == null) Console.WriteLine(" Laptop not found!");
            else
            {
                Console.Clear();
                string data;
                string line = "──────────────────────────────────────────────────────────────────────────────────────────────────────────────────";
                string title = "Laptop infomation";
                int lengthLine = line.Length + 2;
                int position = lengthLine / 2 + title.Length / 2 - 1;
                Console.WriteLine(" ┌{0}┐", line);
                Console.WriteLine(" │{0," + position + "}{1," + (lengthLine - position - 1) + "}", title, "│");
                Console.WriteLine(" ├{0}┤", line);
                Console.WriteLine(" │{0," + (lengthLine - 1) + "}", "│");
                Console.WriteLine(" │ Laptop Id:   {0}{1," + (lengthLine - 15 - laptop.LaptopId.ToString().Length) + "}", laptop.LaptopId, "│");
                Console.WriteLine(" │ Laptop name: {0}{1," + (lengthLine - 15 - laptop.LaptopName.Length) + "}", laptop.LaptopName, "│");
                Console.WriteLine(" │ Manufactory: {0}{1," + (lengthLine - 15 - laptop.ManufactoryInfo.ManufactoryName.Length) + "}", laptop.ManufactoryInfo.ManufactoryName, "│");
                Console.WriteLine(" │ Category:    {0}{1," + (lengthLine - 15 - laptop.CategoryInfo.CategoryName.Length) + "}", laptop.CategoryInfo.CategoryName, "│");
                Console.WriteLine(" │ CPU:         {0}{1," + (lengthLine - 15 - laptop.CPU.Length) + "}", laptop.CPU, "│");
                Console.WriteLine(" │ RAM:         {0}{1," + (lengthLine - 15 - laptop.Ram.Length) + "}", laptop.Ram, "│");
                Console.WriteLine(" │ Hard drive:  {0}{1," + (lengthLine - 15 - laptop.HardDrive.Length) + "}", laptop.HardDrive, "│");
                Console.WriteLine(" │ VGA:         {0}{1," + (lengthLine - 15 - laptop.VGA.Length) + "}", laptop.VGA, "│");
                data = laptop.Display;
                if (data.Length > 99)
                {
                    var lines = Utility.LineFormat(data, 99);
                    Console.WriteLine(" │ Display:     {0}{1," + (lengthLine - 15 - lines[0].Length) + "}", lines[0], "│");
                    for (int i = 1; i < lines.Count; i++)
                        Console.WriteLine(" │              {0}{1," + (lengthLine - 15 - lines[i].Length) + "}", lines[i], "│");
                }
                else
                {
                    Console.WriteLine(" │ Display:     {0}{1," + (lengthLine - 15 - data.Length) + "}", data, "│");
                }
                Console.WriteLine(" │ Battery:     {0}{1," + (lengthLine - 15 - laptop.Battery.Length) + "}", laptop.Battery, "│");
                Console.WriteLine(" │ Weight:      {0}{1," + (lengthLine - 15 - laptop.Weight.Length) + "}", laptop.Weight, "│");
                Console.WriteLine(" │ Materials:   {0}{1," + (lengthLine - 15 - laptop.Materials.Length) + "}", laptop.Materials, "│");
                data = laptop.Ports;
                if (data.Length > 99)
                {
                    var lines = Utility.LineFormat(data, 99);
                    Console.WriteLine(" │ Ports:       {0}{1," + (lengthLine - 15 - lines[0].Length) + "}", lines[0], "│");
                    for (int i = 1; i < lines.Count; i++)
                        Console.WriteLine(" │              {0}{1," + (lengthLine - 15 - lines[i].Length) + "}", lines[i], "│");
                }
                else
                {
                    Console.WriteLine(" │ Ports:       {0}{1," + (lengthLine - 15 - data.Length) + "}", data, "│");
                }
                Console.WriteLine(" │ Network and connection: {0}{1," + (lengthLine - 26 - laptop.NetworkAndConnection.Length) + "}", laptop.NetworkAndConnection, "│");
                Console.WriteLine(" │ Security:    {0}{1," + (lengthLine - 15 - laptop.Security.Length) + "}", laptop.Security, "│");
                Console.WriteLine(" │ Keyboard:    {0}{1," + (lengthLine - 15 - laptop.Keyboard.Length) + "}", laptop.Keyboard, "│");
                Console.WriteLine(" │ Audio:       {0}{1," + (lengthLine - 15 - laptop.Audio.Length) + "}", laptop.Audio, "│");
                Console.WriteLine(" │ Size:        {0}{1," + (lengthLine - 15 - laptop.Size.Length) + "}", laptop.Size, "│");
                Console.WriteLine(" │ Operating system: {0}{1," + (lengthLine - 20 - laptop.OS.Length) + "}", laptop.OS, "│");
                Console.WriteLine(" │ Quantity:    {0}{1," + (lengthLine - 15 - laptop.Quantity.ToString().Length) + "}", laptop.Quantity, "│");
                string price = laptop.Price.ToString("N0") + " VNĐ";
                Console.WriteLine(" │ Price:       {0}{1," + (lengthLine - 15 - price.Length) + "}", price, "│");
                Console.WriteLine(" │ Warranty period: {0}{1," + (lengthLine - 19 - laptop.WarrantyPeriod.Length) + "}", laptop.WarrantyPeriod, "│");
                Console.WriteLine(" └{0}┘", line);

            }
            Console.CursorVisible = false;
            Console.WriteLine("  Press any key to back..."); Console.ReadKey(true);
        }
        string line = "___________________________________________________";
                string title = "SEARCH APPLICATION";
                int lengthLine = line.Length + 2;
                int position = lengthLine / 2 + title.Length / 2 - 1;




                Console.WriteLine(" ┌---------------------------------------┐");
                Console.WriteLine(" |Login...                               |");
                Console.WriteLine(" └---------------------------------------┘");




                if (username.Length == 0) {
                        Console.Write ("  * Username: ");
                        username = Console.ReadLine ();
                    } else {
                        Console.WriteLine ("  | Username: " + username);
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

                    Console.WriteLine ("  | Password: " + new string ('*', password.Length));