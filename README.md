Jest to gra na VR polegająca na łapaniu kulki wystrzeliwanej przez armatkę i odrzucaniu jej w poruszającą się tarcze.
Aby rozpocząć rundę, trzeba wcisnąć interaktywny guzik, później złapać wystrzeloną kulkę i ją odrzucić.
W przypadku trafienia w cel (trafienie w collider) gracz otrzymuje punkt (pokazane na World Space Canvas) i po losowym czasie zostanie wystrzelona nowa kulka. Poziom trudności rośnie wraz z konsekwentnymi trafieniami.
W przypadku spudłowania przy rzucie lub niezłapania piłki (sprawdzane za pomocą dodatkowych colliderów na planszy) runda zostaje uznana za przegraną - reset licznika punktów oraz poziomu trudności, pojawienie się ponownie przycisku do startu rundy.
Wszystkie mechaniki VR zostały stworzone z pomocą VRTK z Unity Asset Store, a testy (w tym nagrane demo) zostały wykonane na symulatorze, a nie prawdziwym zestawie VR.

Demo:
https://user-images.githubusercontent.com/16005312/181618213-d09099ee-649d-4f9e-9bfc-0c046bd99288.mp4
