using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpDesignPatternDemo
{
    public class FacadePattern
    {
        FacadePattern()
        {

        }
    }

    /// <summary>
    /// 外观类
    /// </summary>
    public class RegistrationFacade
    {
        private RegisterCourse registerCorse;
        private NotifyStudent notifyStudent;

        public RegistrationFacade()
        {
            registerCorse = new RegisterCourse();
            notifyStudent = new NotifyStudent();
        }

        public bool RegisterCourse(string courseName,string studentName)
        {
            if(!registerCorse.CheckAvailable(courseName))
            {
                return false;
            }
            return notifyStudent.Notify(studentName);
        }
    }

    #region 子系统
    //相当于子系统A
    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }

    //相当于子系统B
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }
    #endregion
}
