using System;

namespace Console4ChainOfResponsibility
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            LeaveRequest leaveTwoDays = new(2, "grey1");
            LeaveRequest leaveSixDays = new(6, "grey2");
            LeaveRequest leaveEightDays = new(8, "grey3");

            Approver PM = new Manager("jon1");
            Approver DM = new DepartmentManager("jon2");
            Approver GM = new GeneralManager("jon3");

            //Set Chain of Responsibility
            PM.NextApprover = DM;
            DM.NextApprover = GM;

            PM.LeaveRequest(leaveTwoDays);
            PM.LeaveRequest(leaveSixDays);
            PM.LeaveRequest(leaveEightDays);

            Console.ReadLine();
        }
    }

    public class GeneralManager : Approver
    {
        public GeneralManager(string name)
            : base(name) { }
        public override void LeaveRequest(LeaveRequest request)
        {
            if (request.Day < 30)
            {
                Console.WriteLine("總經理{0}審批{1}請假", this.Name, request.Name);
            }
            else
            {
                Console.WriteLine("審批困難");
            }
        }
    }

    public class DepartmentManager : Approver
    {
        public DepartmentManager(string name)
            : base(name) { }
        public override void LeaveRequest(LeaveRequest request)
        {
            if (request.Day < 7)
            {
                Console.WriteLine("部門經理{0}審批{1}請假", this.Name, request.Name);
            }
            else
            {
                NextApprover.LeaveRequest(request);
            }
        }
    }

    public class Manager : Approver
    {
        public Manager(string name)
            :base(name){}

        public override void LeaveRequest(LeaveRequest request)
        {
            if (request.Day<3)
            {
                Console.WriteLine("專案經理{0}審批{1}請假",this.Name,request.Name);
            }
            else
            {
                NextApprover.LeaveRequest(request);
            }
        }
    }

    //Approver
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }
        public string Name { get; set; }
        public Approver(string name)
        {
            this.Name = name;
        }
        public abstract void LeaveRequest(LeaveRequest request);
    }

    public class LeaveRequest
    {
        public int Day { get; set; }
        public string Name { get; set; }

        public LeaveRequest(int day, string name)
        {
            this.Day = day;
            this.Name = name;
        }
    }
}
