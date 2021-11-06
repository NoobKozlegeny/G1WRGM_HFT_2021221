using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1WRGM_HFT_2021221.Data;
using G1WRGM_HFT_2021221.Models;

namespace G1WRGM_HFT_2021221.Repository.Interfaces
{
    public interface IYTContentCreatorRepository : IRepository<YTContentCreator>
    {
        void ChangeSubscriberCount(int id, int newCount);
    }
}
