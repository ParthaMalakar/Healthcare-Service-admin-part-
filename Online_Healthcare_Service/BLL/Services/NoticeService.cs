using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class NoticeService
    {
        public static List<NoticeDTO> Get()
        {
            var data = DataAccessFactory.NoticeDataAccess().Get();
            var Notices = new List<NoticeDTO>();

            foreach (var item in data)
            {
                NoticeDTO AD = new NoticeDTO()
                {
                    Notice_Id = item.Notice_Id,
                    Subject = item.Subject,
                    Description = item.Description,
                    Issue_time = item.Issue_time,
                    Due_time = item.Due_time,
                    Status = item.Status
                };
                Notices.Add(AD);

            }

            return Notices;
        }

        public static NoticeDTO Get(int id)
        {
            var item = DataAccessFactory.NoticeDataAccess().Get(id);
            if (item != null)
            {
                NoticeDTO AD = new NoticeDTO()
                {
                    Notice_Id = item.Notice_Id,
                    Subject = item.Subject,
                    Description = item.Description,
                    Issue_time = item.Issue_time,
                    Due_time = item.Due_time,
                    Status = item.Status
                };
                return AD;
            }
            return null;
        }

        public static bool Create(NoticeDTO item)
        {
            Notice AD = new Notice()
            {
                Notice_Id = item.Notice_Id,
                Subject = item.Subject,
                Description = item.Description,
                Issue_time = item.Issue_time,
                Due_time = item.Due_time,
                Status = item.Status

            };
            return DataAccessFactory.NoticeDataAccess().Create(AD);
        }

        public static bool Update(NoticeDTO item)
        {

            Notice AD = new Notice()
            {
                Notice_Id = item.Notice_Id,
                Subject = item.Subject,
                Description = item.Description,
                Issue_time = item.Issue_time,
                Due_time = item.Due_time,
                Status = item.Status

            };
            return DataAccessFactory.NoticeDataAccess().Update(AD);

        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.NoticeDataAccess().Delete(id);
        }
    }
}
