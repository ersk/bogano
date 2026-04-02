using Ersk43.Bogano.Mono.UI.Entities;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk43.Bogano.Mono.UI.Systems.Slider
{
    //public class SliderUpdate : EntityUpdateSystem
    //{
    //    private ComponentMapper<SliderEntity> sliderMapper;

    //    public SliderUpdate() : base(Aspect.One(typeof(SliderEntity)))
    //    {
    //        FlexFactory flexFactory = new();
    //    }

    //    public override void Initialize(IComponentMapperService mapperService)
    //    {
    //        sliderMapper = mapperService.GetMapper<SliderEntity>();
    //    }

    //    public override void Update(GameTime gameTime)
    //    {
    //        foreach (var sliderEntityId in ActiveEntities)
    //        {
    //            SliderEntity sliderEntity = sliderMapper.Get(sliderEntityId);
    //            if (sliderEntity.isSliding)
    //            {
    //                sliderEntity.value.value += 10;
    //            }
    //        }
    //    }
    //}
}
