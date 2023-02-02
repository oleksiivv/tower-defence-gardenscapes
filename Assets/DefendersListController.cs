using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Linq;

public class DefendersListController : MonoBehaviour
{
    public List<BaseDefender> AllDefenders = new List<BaseDefender>();

    public List<BaseDefender> ChoosenDefenders = new List<BaseDefender>();

    private int MaxDefendersNumber;

    public List<Image> imgSlots;
    public List<Text> textSlots;

    private List<DefenderSlot> Slots;

    public AllDefendersListController allDefendersListController;

    public static bool GameStarted = false;

    public PlaceObjectsController placeObjectsController;


    void Start(){
        GameStarted = false;

        MaxDefendersNumber = 6;

        AllDefenders.Add(new BaseDefender(60, allDefendersListController.defendersSprite[0]));
        AllDefenders.Add(new BaseDefender(100, allDefendersListController.defendersSprite[1]));
        AllDefenders.Add(new BaseDefender(60, allDefendersListController.defendersSprite[2]));
        AllDefenders.Add(new BaseDefender(80, allDefendersListController.defendersSprite[3]));
        AllDefenders.Add(new BaseDefender(130, allDefendersListController.defendersSprite[4]));
        AllDefenders.Add(new BaseDefender(200, allDefendersListController.defendersSprite[5]));

        TurnOffAllSlots();

        //Debug.Log(AllDefenders.Count);
        //Debug.Log(ChoosenDefenders.Count);

        allDefendersListController.FillAllDefendersSlots();
    }

    void TurnOffAllSlots(){
        for(int i = 0; i < imgSlots.Count; i++){
            imgSlots[i].gameObject.SetActive(false);
            textSlots[i].gameObject.SetActive(false);
        }
    }

    void TurnOffSlot(int id){
        imgSlots[id].gameObject.SetActive(false);
        textSlots[id].gameObject.SetActive(false);
    }

    public void Choose(int id){
        if(!HomeController.alive)return;
        if(!GameStarted ){
            
            if(EventSystem.current.currentSelectedGameObject.name.Contains(':')){
                if(!allDefendersListController.slots[Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name.Split(':')[0])].gameObject.activeSelf){
    
                    TurnOffAllSlots();
                    allDefendersListController.CancelClickHandler(Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name.Split(':')[0]), Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name.Split(':')[1]));
                    
                }
                return;
            }
        }
        if(ChoosenDefenders.Count < MaxDefendersNumber){
            ChoosenDefenders.Add(AllDefenders[id]);
            FillSlots(imgSlots, textSlots, ChoosenDefenders);

            imgSlots[ChoosenDefenders.Count-1].gameObject.name = (id).ToString()+":"+(ChoosenDefenders.Count-1).ToString();
            imgSlots[ChoosenDefenders.Count-1].gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            imgSlots[ChoosenDefenders.Count-1].gameObject.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() => { placeObjectsController.Choose(id); }));
            
        }
        
        //Debug.Log("Id:"+Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name.Split(':')[0].ToString()));
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        //Debug.Log(imgSlots[ChoosenDefenders.Count-1].gameObject.name+"["+(ChoosenDefenders.Count - 1).ToString()+"]: "+id.ToString());        

    }

    public void CancelChoose(int id, int pos){
        for(int i=pos;i < ChoosenDefenders.Count-1; i++){
            ChoosenDefenders[i] = ChoosenDefenders[i+1];
            imgSlots[i-pos].name = imgSlots[i-pos].name.Split(':')[0]+':'+(i-pos).ToString();
        }

        if(pos+1<ChoosenDefenders.Count){
            imgSlots[pos].name = imgSlots[pos+1].name;
        }
        ChoosenDefenders.RemoveAt(ChoosenDefenders.Count-1);
        
        allDefendersListController.slots[id].gameObject.SetActive(true);
        allDefendersListController.prices[id].gameObject.SetActive(true);

        FillSlots(imgSlots, textSlots, ChoosenDefenders);
    }



    public void FillSlots(List<Image> _imgSlots, List<Text> _textSlots, List<BaseDefender> _ChoosenDefenders){
        if(Slots!=null)Slots.Clear();
        Slots = new List<DefenderSlot>();

        for(int i = 0; i < _ChoosenDefenders.Count; i++){
            
            Slots.Add(new DefenderSlot(){image = _imgSlots[i], defender = _ChoosenDefenders[i].ShowPrice(_textSlots[i]), price = _textSlots[i] } );

            Slots[i].defender.ShowPrice(_textSlots[i]);
            Slots[i].defender.ShowSprite(_imgSlots[i]);
            _imgSlots[i].gameObject.SetActive(true);
            _textSlots[i].gameObject.SetActive(true);
            
        }

    }

    public void FillAvailableSlots(List<Image> _imgSlots, List<Text> _textSlots, List<BaseDefender> _ChoosenDefenders){
        Slots = new List<DefenderSlot>();

        for(int i = 0; i < _ChoosenDefenders.Count; i++){
            Slots.Add(new DefenderSlot(){image = _imgSlots[i], defender = _ChoosenDefenders[i].ShowPrice(_textSlots[i]) } );
        }

    }


    void SortButtons(List<Image> img){
        for(int i = 0; i < img.Count; i++){
            int n;
            if(int.TryParse(img[i].gameObject.name, out n)){
                if(Convert.ToInt32(img[i].gameObject.name) != i){
                    var tmp = img[i];
                    img[i] = img.Where(e => e.gameObject.name == i.ToString()).First();
                    img[img.IndexOf(img[i])] = tmp;
                }
            }
        }
    }
}
