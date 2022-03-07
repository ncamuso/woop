using SpoilBlock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpoilBlock.DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace SpoilBlock.DAL.Concrete
{
    public class WoopUserMediumRepository : Repository<WoopuserMedium>, IWoopUserMediumRepository
    {
        public WoopUserMediumRepository(WOOPDbContext ctx) : base(ctx) 
        { }

        public int GetBlockageLevel(int id)
        {
            return GetAll().Where(x => x.Id == id).Select(x => x.BlockageLevel).Single();   
        }
         IEnumerable<Medium> IWoopUserMediumRepository.GetListOfShowsForUser(int? id)
        {
            
            var accounts = GetAll().Select(a => a.UserId).ToList();
            try
            {
                if (id != null)
                {
                    if (accounts.Contains((int)id))
                    {
                        var mediaList = new List<Medium>();
                        mediaList = GetAll().Include(a => a.Media).Where(a => a.UserId == id).Select(a => a.Media).ToList();
                        if (mediaList != null)
                        {
                            return mediaList.OrderBy(u => u.Title);
                        }
                        throw new Exception();
                    }
                    throw new InvalidDataException();
                }
                throw new NullReferenceException();

            }

            catch (NullReferenceException err)
            {
                throw new ArgumentNullException();
            }
            catch (InvalidDataException err)
            {
                
                return Enumerable.Empty<Medium>();
            }
            catch (Exception err)
            {
                return Enumerable.Empty<Medium>();
            }
            
           
        }
    }
}
