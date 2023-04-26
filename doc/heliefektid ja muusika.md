# Heliefektid ja muusika
Planeeritud efektid:

## Hüppamine
Hüppamise heli salvestasin kasutades telefoni pehme vaiba peal hüpates. Mängu vaatest pidi heli oluliselt lühendama (ka pisut kiirendama), kuna mängu tegelane jõudis hüppamise heli jooksul juba ka maanuda.

## Maandumine
Hetkel veel tegemata (ajastamine nõuab ka läbi mõtlemist).

## Jooksmine / kõndimine
Jooksmise helist on olemas erinevaid versioone. Üks on salvestatud veepudeli loksutamise teel, teine versioon mööda treppe liikudes.

## Muusikaline taust
Kuna mäng on pikslikunsti elemente, siis mõte oleks 8 või 16 bittist muusikalist tausta kasutada. Otsingute käigus leidsin sellise [loo](https://freemusicarchive.org/music/onys/single/tension-1/)

## Helide mahamängimise lahendus
Helide mahamängimise lahendus baseerub https://learn.unity.com/tutorial/architecture-and-polish?projectId=5c514a00edbc2a0020694718# näitel (osa 2). Mängu on lisatud tühi GameObject, kuhu külge lisasin 2 AudioSouce komponenti, mis omakorda on ühendatud SoundManager.cs skriptiga. 

Helide mahamängimiseks erinevate objekide puhul piisab nüüd muutuja defineerimisest skriptis näide:
```
public class PushbackObstacle : MonoBehaviour
{
    ...
    public AudioClip pushSound;
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ...
            SoundManager.instance.PlaySingle(pushSound);
            ...
        }
    }
}
```
