using System;
using System.Transactions;

namespace SinglyLinkedList {
    class Node {
        public string value;
        public Node next;

        public Node(string value){
            this.value = value;
            this.next = null;
        }
    }

    class LinkedList {
        public Node head;

        public LinkedList(){
            this.head = null;
        }

        public void AddFirst(string value){
            Node newNode = new Node(value);
            newNode.next = head;
            head = newNode;
        }

        public void RemoveFirst(){
            if (head == null){
                Console.WriteLine("List is already empty");
            } else {
                head = head.next;
            }
        }

        public void AddLast(string value){
            Node newNode = new Node(value);
            if (head == null){
                head = newNode;
            } else {
                Node current = head;
                while (current.next != null){
                    current = current.next;
                }
                current.next = newNode;
            }
        }

        public void RemoveLast(){
            if (head == null){
                Console.WriteLine("list is already empty");
            } else if (head.next == null){
                Console.WriteLine(head.value + " has been removed. the list is empty");
                head = null;
            } 
            else {
                Node current = head;
                while(current.next.next != null){
                    current = current.next;
                }
                current.next = null;
            }
        }

        public void Find(string data){
            Node current = head;
            bool found = false;

            if (current == null){
                Console.WriteLine("the list is still empty");
            }
            // else if (current.value == data){
            //     Console.WriteLine(data + " has been found");
            // }
            else {
                while(current != null){
                    if (current.value == data){
                        Console.WriteLine(data + " has been found");
                        found = true;
                        break;
                    }
                    current = current.next;
                }
                if(!found){
                    Console.WriteLine(data + " is not found");
                }
            }
        } //find

        public void ShowAll(){
            if (head == null){
                Console.WriteLine("List is empty.");
            } else {
                Node current = head;
                while(current != null){
                    Console.Write(current.value + " -> ");
                    current = current.next;
                }
                Console.Write("end");
                Console.WriteLine();
            }
        }

        public void GetByIndex(int index){
            if (index<0){
                Console.WriteLine("invalid index. Index must start with 0");
            } else{
                int currentIndex = 0;
                Node current = head;

                while(current != null){
                    if(currentIndex == index){
                        Console.WriteLine($"the value of index {index} is {current.value}");
                        return; //kalo udah ketemu, loop-nya diberentiin
                    }
                    current = current.next;
                    currentIndex++;
                }
                Console.WriteLine("index out of bounds"); //kalo sampe ketemu ini, berarti index udah melebihi batas
            }
        }//getbyindex

        public void RemoveByIndex(int index){

            if (index<0){
                Console.WriteLine("invalid index. Index must start with 0");
                return;
            } 
            if (head == null){
                Console.WriteLine("the list is still empty");
                return;
            }
            if (index == 0){
                Console.WriteLine($"index {index} ['{head.value}'] has been removed");
                head = head.next;
                return;
            }
            Node current = head;
            int currentIndex = 0;

            while(current != null && currentIndex < index - 1){
                current = current.next;
                currentIndex++;
            }

            if (current == null || current.next == null) {
            Console.WriteLine("Index out of bounds.");
            return;
            }

            Console.WriteLine($"Index {index} ['{current.next.value}'] has been removed.");
            current.next = current.next.next;
        }

    } //linkedlist

    public class Program{
        public static void Main (string[] args){
                LinkedList LL = new LinkedList();
                LL.AddFirst("a");
                LL.AddLast("b");
                LL.AddLast("c");
                LL.ShowAll();
                LL.RemoveByIndex(0);
                LL.ShowAll();
                // LL.GetByIndex(0);
                // LL.GetByIndex(7);
                // LL.Find("a");
                // LL.Find("c");
                // LL.RemoveFirst();
                // LL.ShowAll();
                // LL.RemoveLast();
                // LL.ShowAll();
                // LL.RemoveLast();
                // LL.Find("a");
                // LL.ShowAll();
        }// main
    }
}//namespace