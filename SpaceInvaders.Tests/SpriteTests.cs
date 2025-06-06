using Xunit;
using Space_Invaders;

namespace SpaceInvaders.Tests
{
    public class SpriteTests
    {
        [Fact]
        public void SpriteAtZeroZeroCollidesWithSpriteAtOneZero()
        {
            var sprite1 = new Sprite { x = 0, y = 0, Imagen = "A" };
            var sprite2 = new Sprite { x = 1, y = 0, Imagen = "B" };

            Assert.True(sprite1.ColisionaCon(sprite2));
        }
    }
}
