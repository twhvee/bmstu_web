using Course.Model;
using RevWorld.Model;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Service
{
    public class TagService
    {

        protected ITagsRepository _tagsRepository;
        public TagService(ITagsRepository tags)
        {
            _tagsRepository = tags;
        }
        public async Task<int> AddTag(Tag tag)
        {
            return await _tagsRepository.Create(tag);
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await _tagsRepository.TakeAll();
        }

        public async Task<Tag> GetTagByName(string name)
        {
            return await _tagsRepository.FindByName(name);

        }

        public async Task<Tag> GetTag(int id)
        {
            Tag tag = await _tagsRepository.TakeById(id);
            if (tag == null)
                return null;
            return  await _tagsRepository.TakeById(id);
        }
    }
}
