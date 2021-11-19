using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetTopViewsVideo
{
    class GetTopLikesVideoListQueryHandler : IRequestHandler<GetTopLikesVideoListQuery, List<GetTopLikesVideoListDto>>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IContentCreatorRepo _contentCreatorRepo;
        private readonly IVideoRepository _videoRepository;
        
       


        public GetTopLikesVideoListQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository,
          IAdvertisementRepo advertisementRepo, IContentCreatorRepo contentCreatorRepo,
          IVideoRepository videoRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
            _advertisementRepo = advertisementRepo;
            _contentCreatorRepo = contentCreatorRepo;
            _videoRepository = videoRepository;
        }
        public async Task<List<GetTopLikesVideoListDto>> Handle(GetTopLikesVideoListQuery request, CancellationToken cancellationToken)
        {
            List<GetTopLikesVideoListDto> result = new List<GetTopLikesVideoListDto>();
            var topVideo =  _videoPageRepository.GetAllVideos();
           
            for (var i = 0; i < topVideo.Count; i++)
            {
                
               
                    result.Add(new GetTopLikesVideoListDto()
                    {
                        topVideoId = topVideo[i].VideoId,
                        Title = topVideo[i].Title,
                        topViews = await _videoPageRepository.GetViewsById(topVideo[i].VideoId),
                        topLikes = await _videoPageRepository.GetLikesById(topVideo[i].VideoId),
                        Decription = topVideo[i].Decription,
                        videoImage = topVideo[i].VideoImage,
                        createdOn = topVideo[i].CreatedOn
                    });
                

            }

            return result.OrderByDescending(p => p.topLikes).ToList();
        }
    }
}
