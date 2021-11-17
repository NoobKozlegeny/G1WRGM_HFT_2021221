using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Models;
using G1WRGM_HFT_2021221.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Logic.Classes
{
    public class YTContentCreatorLogic : IYTContentCreatorLogic
    {
        IYTContentCreatorRepository ytccRepo;

        public YTContentCreatorLogic(IYTContentCreatorRepository ytccRepo) //DEPENDENCY INJECTION
        {
            this.ytccRepo = ytccRepo;
        }

        //NON-CRUD
        public void ChangeSubscriberCount(int id, int newCount)
        {
            ytccRepo.ChangeSubscriberCount(id, newCount);
        }

        //CRUD
        public void Create(YTContentCreator content)
        {
            ytccRepo.Create(content);
        }

        public void Delete(int id)
        {
            ytccRepo.Delete(id);
        }

        public YTContentCreator Read(int id)
        {
            return ytccRepo.Read(id);
        }

        public IList<YTContentCreator> ReadAll()
        {
            return ytccRepo.ReadAll().ToList();
        }

        public void Update(YTContentCreator content)
        {
            ytccRepo.Update(content);
        }
    }
}
