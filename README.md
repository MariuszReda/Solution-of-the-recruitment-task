# Solution-of-the-recruitment-task
```cs
Zadanie „Spotkajmy się” 
Zaimplementować w języku C# algorytm, który na podstawie kalendarzy dwóch 
osób oraz oczekiwanej długości spotkania przedstawi propozycję możliwych terminów 
spotkań.
Na wejściu: 
• kalendarze 2 osób z określonymi godzinami pracy oraz zaplanowanymi już 
spotkaniami
• oczekiwany czas trwania spotkania
Jako wynik program powinien zwrócić zakresy, w których można zorganizować spotkania. 
meeting duration: [00:30]
```
#Calendar 1
```json

{
  "working_hours": {
    "start": "09:00",
    "end": "19:55"
  },

  "planned_meeting": [
    {
      "start": "09:00",
      "end": "10:30"
    },
    {
      "start": "12:00",
      "end": "13:00"
    },
    {
      "start": "16:00",
      "end": "18:00"
    }
  ]
}
```
#Calendar 2
```json

{
  "working_hours": {
    "start": "10:00",
    "end": "18:00"
  },

  "planned_meeting": [
    {
      "start": "10:00",
      "end": "11:30"
    },
    {
      "start": "12:30",
      "end": "14:30"
    },
    {
      "start": "14:30",
      "end": "15:00"
    },
    {
      "start": "16:00",
      "end": "17:00"
    }
  ]
}
```
Przykładowy output:
```cs
[["11:30","12:00"], ["15:00", "16:00"], ["18:00", "18:30"]]
```
