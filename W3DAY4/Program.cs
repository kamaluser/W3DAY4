using System;
using System.Linq;

namespace W3DAY4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] products = { "Bag", "Sweatshirt", "T-Shirt", "Hat" };
            string[] newProducts = new string[products.Length + 1];
            int opr;
            bool check;

            do
            {
                check = true;

                Console.WriteLine("1. Butun Mehsullara Bax");
                Console.WriteLine("2. Secilmis Mehsula Bax (Index deyerine gore)");
                Console.WriteLine("3. Yeni Mehsul Elave Et");
                Console.WriteLine("4. Mehsul Adini Deyis");
                Console.WriteLine("5. Secilmis Mehsulu Sil(ID deyerine gore)");
                Console.WriteLine("0. Cix");


                Console.WriteLine("Emeliyyati Daxil Et: ");
                opr = Convert.ToInt32(Console.ReadLine());




                switch (opr)
                {
                    case 1:
                        ShowProducts(products);
                        break;
                    case 2:
                        ViewProduct(products);
                        break;
                    case 3:
                        AddProductToList(products);
                        break;
                    case 4:
                        ChangeElement(products);
                        break;
                    case 5:
                        RemoveElement(products);
                        break;
                    case 0:
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Emeliyyat Yanlisdir!");
                        break;

                }
            } while (opr != 0);
        }

        #region ShowProducts
        static void ShowProducts(string[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine(products[i]);
            }
        }
        #endregion


        #region ViewProduct
        static void ViewProduct(string[] products)
        {
            Console.WriteLine("Indeksi daxil et: ");
            int indeks = Convert.ToInt32(Console.ReadLine());
            if (indeks >= 0 || indeks < products.Length)
            {
                Console.WriteLine(products[indeks]);
            }
            else
            {
                Console.WriteLine("Indeks Yanlisdir!");
            }
        }

        #endregion


        #region AddProductToList
        static void AddProductToList(string[] products)
        {
            string productWithoutSpace;
            bool check;

            do
            {
                Console.WriteLine("Yeni mehsulun adini daxil edin: ");
                string addedProduct = Console.ReadLine();
                productWithoutSpace = RemoveFirstAndLastSpace(addedProduct);

            } while (productWithoutSpace.Length < 2 || productWithoutSpace.Length > 20);

            string[] newProductList = new string[products.Length + 1];

            check = false;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == productWithoutSpace)
                {
                    check = true;
                    break;
                }
            }

            if (check == true)
            {
                Console.WriteLine("Bu mehsul siyahida movcuddur!");
            }
            else
            {
                newProductList[newProductList.Length - 1] = productWithoutSpace;
                products = newProductList;
            }
        }
        #endregion


        #region ChangeElement
        static void ChangeElement(string[] products)
        {
            Console.WriteLine("Indeksi Daxil Et: ");
            int indeks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deyisilen yeni mehsulun adini daxil et: ");
            string changedProduct = Console.ReadLine();
            try
            {
                products[indeks] = RemoveFirstAndLastSpace(changedProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mesaj: " + ex.Message);
            }


            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine(products[i]);
            }


        }
        static int RemoveFirstSpace(string productName)
        {
            for (int i = 0; i < productName.Length; i++)
            {
                if (productName[i] != ' ')
                {
                    return i;
                }

            }
            return -1;
        }

        static int RemoveLastSpace(string productName)
        {
            for (int i = productName.Length - 1; i >= 0; i--)
            {
                if (productName[i] != ' ')
                {
                    return i;
                }
            }
            return -1;
        }

        static string RemoveFirstAndLastSpace(string productName)
        {
            int startIndex = RemoveFirstSpace(productName);
            int endIndex = RemoveLastSpace(productName);
            string newStr = "";
            if (startIndex == -1 || endIndex == -1)
            {
                return newStr;
            }

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                newStr += productName[i];
            }
            return newStr;

            #endregion


        #region RemoveElement

            static void RemoveElement(string[] products)
            {
                Console.WriteLine("Silmek istediyiniz mehsulun indeksi: ");
                int indeks = Convert.ToInt32(Console.ReadLine());
                string[] newList = new string[products.Length - 1];
                int index = 0;
                try
                {
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (i != indeks)
                        {
                            newList[index] = products[i];
                            index++;
                        }
                    }

                    for (int i = 0; i < newList.Length; i++)
                    {
                        Console.WriteLine(newList[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Mesaj: " + ex.Message);
                }
            }

            #endregion

        }
    }
}
