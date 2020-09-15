using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// Общий интерфейс для всех дайсов. Очень советую юзать интерфейсы - это очень сильная абстракция в C#,, позволяет делать код менее "слипшимся"
public interface IDice
{
    IDiceResult GetDiceResult();
}

[Serializable] // ХЗ - нужен ли этот атрибут, не знаю API UNITY          
public class SixDice : IDice // Реализация интерфейса IDice, типа тут 6-гранный кубик
{
    public readonly GameObject _diceObject;

    public SixDice(GameObject diceObject)
    {
        _diceObject = diceObject;
    }

    public IDiceResult GetDiceResult()
    {
        return null; // заглушка
    }
}


// Можно юзать Интерфейс, который является абстракцией для результата броска кубика
public interface IDiceResult { }

// А можно юзать Базовый абстрактный класс
public abstract class BaseSixDiceResult
{
    protected Sprite sprite;

    protected BaseSixDiceResult(Sprite sprite)
    {
        this.sprite = sprite;
    }
}

// Типа реализация, хуй знает как делать эти реализации - нужно подумать
public class OneDiceResult : BaseSixDiceResult, IDiceResult
{
    public OneDiceResult(Sprite sprite): base(sprite) {}
}


// интерфейс для мешка с кубиками
public interface IDiceBag
{
    IDice GetRandomDice();
}


public abstract class BaseDiceBag
{
    // поле-перечисление кубиков. List<T>, LinkedList<T> или массивы реализуют этот интерфейс
    // Учти, что удалять элементы из массива - очень дорого по памяти и медленно
    // Можно просто назначать элементу null и всё
    // Вроде как лучше всего для этого Linked List (связанный список юзать)
    private IEnumerable<IDice> _dices;

    public BaseDiceBag(IEnumerable<IDice> dices)
    {
        _dices = dices;
    }
}

// Реализация:
public class NewYearDiceBag : BaseDiceBag, IDiceBag
{
    // Конструктор, передавай сюда, например связанный список
    public NewYearDiceBag(LinkedList<IDice> dices) : base(dices) {}

    // Или массив
    public NewYearDiceBag(IDice[] dices) : base(dices) {}

    public IDice GetRandomDice()
    {
        // ТУТ ТИПА ФУНКЦИЯ, ДОСТАЮЩАЯ РАНДОМНЫЙ КУБИК
        return null; // заглушка
    }

    private void RemoveRandomDice()
    {
        // тут удаляй рандомный кубик
        throw new NotImplementedException();// заглушка
    }
}

