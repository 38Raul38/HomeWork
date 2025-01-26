// using ConsoleApp2;
// using ConsoleApp2.Services;
//
// UserService authSystem = new UserService();
// ShowroomServices showroomService = new ShowroomServices();
// Showroom showroom = new Showroom();
// Console.WriteLine("1. Register\n2. Login\n3. Create Showroom\n4. Remove Showroom\n5. Edit Showroom\n6. CRUD\n7. Exit");
//
// string userInput = Console.ReadLine();
// if (userInput == "6")
// {
//     Console.WriteLine("1. Add Car\n2. Remove Car\n3. Update Car\n4. Show Car");
// }
// {
//     
// }
// bool running = true;
// switch (userInput)
// {
//     case "1":
//         Console.WriteLine("Enter username: ");
//         string RegUsername = Console.ReadLine();
//         
//         Console.WriteLine("Enter password: ");
//         string RegPassword = Console.ReadLine();
//         
//         var RegisterDTO = new RegisterDto(RegUsername, RegPassword);
//
//         if (!ValidateService.ValidateRegister(RegisterDTO))
//         {
//             Console.WriteLine("Invalid username or password");
//         }
//         else
//         {
//             authSystem.RegisterUser(RegisterDTO);
//         }
//         break;
//     case "2":
//         Console.WriteLine("Enter username: ");
//         string LogUsername = Console.ReadLine();
//         Console.WriteLine("Enter password: ");
//         string LogPassword = Console.ReadLine();
//         
//         var loginDTO = new LoginDto(LogUsername, LogPassword);
//
//         if (!ValidateService.ValidateLogin(loginDTO))
//         {
//             Console.WriteLine("Invalid username or password");
//         }
//         else
//         {
//
//             authSystem.LoginUser(loginDTO);
//         }
//         break;
//      case "3":
//         Console.Write("Enter Showroom name: ");
//         string name = Console.ReadLine();
//         Console.Write("Enter showroom capacity: ");
//         if (int.TryParse(Console.ReadLine(), out int capacity))
//         {
//             showroomService.CreateShowroom(name, capacity);
//         }
//         else
//         {
//             Console.WriteLine("Invalid input!.");
//         }
//         break;
//      case "4":
//         showroomService.RemoveShowroom();
//          break;
//      case "5":
//         Console.Write("Enter Showroom name: ");
//         string oldName = Console.ReadLine();
//         Console.Write("Enter new name: ");
//         string newName = Console.ReadLine();
//         Console.Write("Enter new capacity: ");
//         if (int.TryParse(Console.ReadLine(), out int newCapacity))
//         {
//             showroomService.EditShowroom(oldName, newName, newCapacity);
//         }
//         else
//         {
//             Console.WriteLine("Invalid input!.");
//         }
//         break;
//      case "6":
//         string choise = Console.ReadLine();
//         switch (choise)
//         {
//             case "1":
//                 showroom.AddCar();
//                 break;
//             case "2":
//                 showroom.DeleteCar();
//                 break;
//             case "3":
//                 showroom.UpdateCar();
//                 break;
//             case "4":
//                 showroom.ShowCars();
//                 break;
//             default:
//                 Console.WriteLine("Invalid Input!");
//                 break;
//         }
//          break;
//      case "7":
//         running = false;
//         break;
//     default:
//         Console.WriteLine("Wrong choice. Try again.");
//         break;
// }

using ConsoleApp2;
using ConsoleApp2.Services;


        UserService authSystem = new UserService();
        ShowroomServices showroomService = new ShowroomServices();
        Showroom showroom = new Showroom();
        List<Showroom> showrooms = new List<Showroom>(); 
        
        // showrooms.Add(new Showroom("Showroom 1", 10));
        // showrooms.Add(new Showroom("Showroom 2", 5));

        Console.WriteLine("1. Register\n2. Login\n3. Create Showroom\n4. Remove Showroom\n5. Edit Showroom\n6. CRUD\n7. Exit");

        string userInput = Console.ReadLine();
        if (userInput == "6")
        {
            Console.WriteLine("1. Add Car\n2. Remove Car\n3. Update Car\n4. Show Car");
        }

        bool running = true;
        switch (userInput)
        {
            case "1":
                Console.WriteLine("Enter username: ");
                string RegUsername = Console.ReadLine();

                Console.WriteLine("Enter password: ");
                string RegPassword = Console.ReadLine();

                var RegisterDTO = new RegisterDto(RegUsername, RegPassword);

                if (!ValidateService.ValidateRegister(RegisterDTO))
                {
                    Console.WriteLine("Invalid username or password");
                }
                else
                {
                    authSystem.RegisterUser(RegisterDTO);
                }
                break;
            case "2":
                Console.WriteLine("Enter username: ");
                string LogUsername = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string LogPassword = Console.ReadLine();

                var loginDTO = new LoginDto(LogUsername, LogPassword);

                if (!ValidateService.ValidateLogin(loginDTO))
                {
                    Console.WriteLine("Invalid username or password");
                }
                else
                {
                    authSystem.LoginUser(loginDTO);
                }
                break;
            case "3":
                Console.Write("Enter Showroom name: ");
                string name = Console.ReadLine();
                Console.Write("Enter showroom capacity: ");
                if (int.TryParse(Console.ReadLine(), out int capacity))
                {
                    showroomService.CreateShowroom(name, capacity);
                }
                else
                {
                    Console.WriteLine("Invalid input!.");
                }
                break;
            case "4":
                showroomService.RemoveShowroom();
                break;
            case "5":
                Console.Write("Enter Showroom name: ");
                string oldName = Console.ReadLine();
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                Console.Write("Enter new capacity: ");
                if (int.TryParse(Console.ReadLine(), out int newCapacity))
                {
                    showroomService.EditShowroom(oldName, newName, newCapacity);
                }
                else
                {
                    Console.WriteLine("Invalid input!.");
                }
                break;
            case "6":
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        showroom.AddCar(showrooms);
                        break;
                    case "2":
                        showroom.DeleteCar(showrooms); 
                        break;
                    case "3":
                        showroom.UpdateCar(showrooms); 
                        break;
                    case "4":
                        showroom.ShowCars(showrooms); 
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
                break;
            case "7":
                running = false;
                break;
            default:
                Console.WriteLine("Wrong choice. Try again.");
                break;
        }
