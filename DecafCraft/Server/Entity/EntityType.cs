using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DecafCraft.Server.Entity
{
    /*
     * Derived from Bukkit's implementation at
     * https://github.com/Bukkit/Bukkit/blob/master/src/main/java/org/bukkit/entity/EntityType.java
     */
    public class EntityType
    {
        private string _name;
        private Type _type;
        private short _typeId;
        private bool _independent;
        private bool _living;
        
        private static readonly Dictionary<string, EntityType> NameMap = new Dictionary<string, EntityType>();
        private static readonly Dictionary<short, EntityType> IdMap = new Dictionary<short, EntityType>();

        public string GetName() => _name;
        public Type GetEntityClass() => _type;
        public short GetTypeId() => _typeId;
        public bool IsSpawnable() => _independent;
        public bool IsAlive() => _living;
        
        public static readonly EntityType DROPPED_ITEM = new EntityType("Item", typeof(IItem), 1);
        public static readonly EntityType EXPERIENCE_ORB = new EntityType("XPOrb", typeof(IExperienceOrb), 2);
        public static readonly EntityType LEASH_HITCH = new EntityType("LeashKnot", typeof(ILeashHitch), 8);
        public static readonly EntityType PAINTING = new EntityType("Painting", typeof(IPainting), 9);
        public static readonly EntityType ARROW = new EntityType("Arrow", typeof(IArrow), 10);
        public static readonly EntityType SNOWBALL = new EntityType("Snowball", typeof(ISnowball), 11);
        public static readonly EntityType FIREBALL = new EntityType("Fireball", typeof(IFireball), 12);
        public static readonly EntityType SMALL_FIREBALL = new EntityType("SmallFireball", typeof(IFireballSmall), 13);
        public static readonly EntityType ENDER_PEARL = new EntityType("ThrownEnderpearl", typeof(IEnderPearl), 14);
        public static readonly EntityType ENDER_SIGNAL = new EntityType("EyeOfEnderSignal", typeof(IEyeOfEnder), 15);
        public static readonly EntityType THROWN_EXP_BOTTOLE = new EntityType("ThrownExpBottle", typeof(IThrownExpBottle), 17);
        public static readonly EntityType ITEM_FRAME = new EntityType("ItemFrame", typeof(IItemFrame), 18);
        public static readonly EntityType WITHER_SKULL = new EntityType("WitherSkull", typeof(IWitherSkull), 19);
        public static readonly EntityType PRIMED_TNT = new EntityType("PrimedTnt", typeof(ITntPrimed), 20);
        public static readonly EntityType FALLING_BLOCK = new EntityType("FallingSand", typeof(IBlockFalling), 21, false);
        public static readonly EntityType FIREWORK = new EntityType("FireworksRocketEntity", typeof(IFirework), 22, false);
        public static readonly EntityType MINECART_COMMAND = new EntityType("MinecartCommandBlock", typeof(IMinecartCommand), 40);
        public static readonly EntityType BOAT = new EntityType("Boat", typeof(IBoat), 41);
        public static readonly EntityType MINECART = new EntityType("MinecartRideable", typeof(IMinecart), 42);
        public static readonly EntityType MINECART_CHEST = new EntityType("MinecartChest", typeof(IMinecartChest), 43);
        public static readonly EntityType MINECART_FURNACE = new EntityType("MinecartFurnace", typeof(IMinecartFurnace), 44);
        public static readonly EntityType MINECART_TNT = new EntityType("MinecartTNT", typeof(IMinecartTnt), 45);
        public static readonly EntityType MINECART_HOPPER = new EntityType("MinecartHopper", typeof(IMinecartHoppper), 46);
        public static readonly EntityType MINECART_MOB_SPAWNER = new EntityType("MinecartMobSpawner", typeof(IMinecartMobSpawner), 47);
        public static readonly EntityType CREEPER = new EntityType("Creeper", typeof(ICreeper), 50);
        public static readonly EntityType SKELETON = new EntityType("Skeleton", typeof(ISkeleton), 51);
        public static readonly EntityType SPIDER = new EntityType("Spider", typeof(ISpider), 52);
        public static readonly EntityType GIANT = new EntityType("Giant", typeof(IGiant), 53);
        public static readonly EntityType ZOMBIE = new EntityType("Zombie", typeof(IZombie), 54);
        public static readonly EntityType SLIME = new EntityType("Slime", typeof(ISlime), 55);
        public static readonly EntityType GHAST = new EntityType("Ghast", typeof(IGhast), 56);
        public static readonly EntityType PIG_ZOMBIE = new EntityType("PigZombie", typeof(IPigZombie), 57);
        public static readonly EntityType ENDERMAN = new EntityType("Enderman", typeof(IEnderman), 58);
        public static readonly EntityType CAVE_SPIDER = new EntityType("CaveSpider", typeof(ISpiderCave), 59);
        public static readonly EntityType SILVERFISH = new EntityType("Silverfish", typeof(ISilverfish), 60);
        public static readonly EntityType BLAZE = new EntityType("Blaze", typeof(IBlaze), 61);
        public static readonly EntityType MAGMA_CUBE = new EntityType("LavaSlime", typeof(IMagmaCube), 62);
        public static readonly EntityType ENDER_DRAGON = new EntityType("EnderDragon", typeof(IEnderDragon), 63);
        public static readonly EntityType WITHER = new EntityType("WitherBoss", typeof(IWither), 64);
        public static readonly EntityType BAT = new EntityType("Bat", typeof(IBat), 65);
        public static readonly EntityType WITCH = new EntityType("Witch", typeof(IWitch), 66);
        public static readonly EntityType PIG = new EntityType("Pig", typeof(IPig), 90);
        public static readonly EntityType SHEEP = new EntityType("Sheep", typeof(ISheep), 91);
        public static readonly EntityType COW = new EntityType("Cow", typeof(ICow), 92);
        public static readonly EntityType CHICKEN = new EntityType("Chicken", typeof(IChicken), 93);
        public static readonly EntityType SQUID = new EntityType("Squid", typeof(ISquid), 94);
        public static readonly EntityType WOLF = new EntityType("Wolf", typeof(IWolf), 95);
        public static readonly EntityType MUSHROOM_COW = new EntityType("MushroomCow", typeof(ICowMushroom), 96);
        public static readonly EntityType SNOWMAN = new EntityType("SnowMan", typeof(ISnowman), 97);
        public static readonly EntityType OCELOT = new EntityType("Ozelot", typeof(IOcelot), 98);
        public static readonly EntityType IRON_GOLEM = new EntityType("VillagerGolem", typeof(IIronGolem), 99);
        public static readonly EntityType HORSE = new EntityType("EntityHorse", typeof(IHorse), 100);
        public static readonly EntityType VILLAGER = new EntityType("Villager", typeof(IVillager), 120);
        public static readonly EntityType ENDER_CRYSTAL = new EntityType("EnderCrystal", typeof(IEnderCrystal), 200);
        public static readonly EntityType SPLASH_POTION = new EntityType(null, typeof(IThrownPotion), -1, false);
        public static readonly EntityType EGG = new EntityType(null, typeof(IEgg), -1, false);
        public static readonly EntityType FISHING_HOOK = new EntityType(null, typeof(IFish), -1, false);
        public static readonly EntityType LIGHTNING = new EntityType(null, typeof(ILightningStrike), -1, false);
        public static readonly EntityType WEATHER = new EntityType(null, typeof(IWeather), -1, false);
        public static readonly EntityType PLAYER = new EntityType(null, typeof(IPlayer), -1, false);
        public static readonly EntityType COMPLEX_PART = new EntityType(null, typeof(IComplexEntityPart), -1, false);
        public static readonly EntityType UNKNOWN = new EntityType(null, null, -1, false);
            
        public EntityType(string name, Type type, short typeId, bool independent = true)
        {
            _name = name;
            _type = type;
            _typeId = typeId;
            _independent = independent;
            
            if(type != null) NameMap.Add(nameof(type).ToLower(), this);
            if(typeId > 0) IdMap.Add(typeId, this);
        }

        public static EntityType FromName(string name) => name == null ? null : NameMap[name.ToLower()];
        public static EntityType FromId(int id) => id > short.MaxValue ? null : IdMap[(short) id];
    }
}