using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReverseService
{
    public class ReversePeriodic
    {
        public static void Process()
        {
            try
            {
                using (StringReverseModel ctx = new StringReverseModel())
                {
                    foreach(var item in ctx.StringReverses)
                    {
                        if(item.IsReversed.HasValue && !item.IsReversed.Value)
                        {
                            item.TextValue = new string(item.TextValue.ToCharArray().Reverse().ToArray());
                            item.IsReversed = true;
                        }
                    }
                    ctx.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "svc_log.txt"), $"\n{ex.ToString()}");
            }
        }
    }
}
