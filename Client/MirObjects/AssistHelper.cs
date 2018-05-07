using Client.MirNetwork;
using Client.MirScenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C = ClientPackets;

namespace Client.MirObjects
{
    class AssistHelper
    {
        private long autoFireTick;
        private long lastFireTick;

        private long lastUseItemTick;

        public void process()
        {
            if (Settings.smartFireHit && CMain.Time - autoFireTick > 3000 && UserObject.User.MP >= 7 && (!GameScene.NextTimeFireHit)
                && (CMain.Time - GameScene.LastFireHitTick > 10000))
            {
                autoFireTick = CMain.Time;
                GameScene.Scene.UseSpell(Spell.FlamingSword);
            }


            /*
                            if g_Config.boSmartFireHit and (GetTickCount - g_dwAutoFireTick > 1000 * 3) and (g_MySelf.m_Abil.MP >= 7) and (not g_boNextTimeFireHit) and (GetTickCount - g_dwLatestFireHitTick >= g_ServerConfig.nFireDelayTime) then begin
                  g_dwAutoFireTick := GetTickCount;
                  pm := FindMagic(26);
                  if pm <> nil then begin
                      {if not IsWarrSkill(pm.Def.wMagicId) then begin
                        if (g_MySelf.m_btHorse > 0) and g_Config.boAutoHorse then SendOnHorse();
                      end;}

                    UseMagic(g_nMouseX, g_nMouseY, pm);
                    ActionKey := 0;
                    g_nTargetX := -1;
                  end;
                end;
                */
            autoUseItem();
        }

        private void autoUseItem()
        {
            if (Settings.autoEatItem)
                autoEatHp();
        }

        private void autoEatHp()
        {
            UserObject User = UserObject.User;
            if (UserObject.User.PercentHealth < Settings.percentHpProtect && CMain.Time - lastUseItemTick > 3000)
            {
                lastUseItemTick = CMain.Time;
                //GameScene.UseItemTime
                for (int i = 0; i < User.Inventory.Length; i++)
                {
                    UserItem item = User.Inventory[i];

                    if (item != null && item.Info != null && item.Info.Name.Equals(Settings.hpItemName))
                    {
                        Network.Enqueue(new C.UseItem { UniqueID = item.UniqueID });
                        break;
                    }
                }
            }
        }
    }
}
