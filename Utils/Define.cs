namespace text_rpg.Utils
{
    internal class Define
    {
        public enum ItemType
        {
            Consum,
            Equip
        }

        public enum Parts
        {
            Weapon,
            Head,
            Body,
            Shoes
        }

        public enum GameStages
        {
            Intro,
            Login,
            Base,
            Stat
        }

        public enum Buff
        {
            atk,
            def,
            cri,
            miss,
            hp
        }

        public enum SetEquip
        {
            세트효과없음,
            종이세트,
            나무세트,
            철세트,
            아다만세트
        }

        // enum 자리로 불러오느는법

    }
}
