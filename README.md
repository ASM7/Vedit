# Vedit
Простой векторный редактор. Позволяет создавать и редактировать изображения, состоящие из примитивных объектов. Поддерживается возможность сохранения в бинарном векторном формате и экспорт в BMP. 

## Над проектом работали
Максим Акулин, Алексей Захаров, Станислав Яркеев

## План презентации

### Вступление

Мы делали векторный графический редактор для рисования простых изображений.

Клик по кнопке на панели инструментов добавляет новую фигуру. У каждой фигуры для редактирования доступен свой список свойств, влияющих на отображение. Можно перемещать фигуры и менять их размеры.

<картинки, гифки>

Мы продемонстрировали расширяемость набора фигур на примере овалов и отрезков.

Возможна работа с несколькими форматами изображений:
* свой векторный формат (загрузка и сохранение)
* экспорт в BMP.

Максим занимался пользовательским интерфейсом, Алексей — фигурами и их сереализацией, Стас — общей логикой приложения.

### Описание точек расширения

Наши точки расширения - добавление новых
* фигур
* форматов ввода / вывода
* действий в меню
* кнопок панели инструментов.

Подробно рассмотрим только добавление фигур. Для добавления новой фигуры нужно написать класс, реализующий маркировочный интерфейс IShape:
```c#
public interface IShape : IDrawable { }
```
Интерфейс IDrawable включает в себя метод и параметры отрисовки:
```c#
public interface IDrawable
{
    Vector Position { get; set; }
    Size BoundingRectSize { get; set; }
    float Angle { get; set; }

    void Paint(Bitmap bitmap);
}
```
Для упрощения процесса рисования фигуру можно сделать наследником класса [DrawableObject](/Vedit/Domain/DrawableObject.cs), который инкапсулирует в себе операции смещения и вращения холста:
```c#
public abstract class DrawableObject : IDrawable
{
    ...
    public void Paint(Graphics graphics)
    {
        graphics.TranslateTransform(Position);

        var centerOffset = new Vector(BoundingRectSize.Width, BoundingRectSize.Height) * 0.5;
        graphics.TranslateTransform(centerOffset);
        graphics.RotateTransform(Angle);
        graphics.TranslateTransform(-1 * centerOffset);

        PaintStraight(graphics);
        
        graphics.TranslateTransform(centerOffset);
        graphics.RotateTransform(-Angle);
        graphics.TranslateTransform(-1 * centerOffset);
        
        graphics.TranslateTransform(-1 * Position);
    }

    protected abstract void PaintStraight(Graphics graphics);
}
```
Для получения и редактирования свойств фигуры используется стандартный компонент PropertyGrid.

### Общая структура решения

Слой UI содержит классы, связанные с элементами интерфейса (главная форма, панель инструментов с кнопками, панель редактирования свойств фигуры, действия меню).

В слое приложения находится класс [Editor](/Vedit/App/Editor.cs), в котором сосредоточена логика обработки действий пользователя, связанных с выделением и преобразованием фигур.

_Editor_

Основные классы предметной области — это [фигуры](/Vedit/Domain/Shapes/) и [документ](/Vedit/Domain/Document.cs), содержащий ссылки на все фигуры, а также настройки отображения. Editor хранит ссылку на документ.

_Document, Ellipse_

Инфраструктурный слой составляют различные методы расширения, класс [Vector](/Vedit/Infrastructure/Vector.cs), используемый при рассчёте координат геометрических объектов, а также интерфейсы и классы, связанные с сереализацией.

[BinarySerializer - обёртка над BinaryFormatter](/Vedit/Infrastructure/Serialization/BinarySerializer.cs)

### Сборка зависимостей

Сборка графа зависимостей происходит в точке входа в программу ([Program.cs](/Vedit/Program.cs)).

<код>

Точки расширения собираются с помощью конвенций. Остальное — явным конфигурированием. Классы главной формы и редактора сделаны синглтонами.

Для автоматического создания generic-классов ```ShapeButton<TShape>``` для каждой из фигур используется рефлексия:

```c#
static Type[] GenerateShapeButtonTypes()
{
    return Assembly.GetAssembly(typeof(Program))
        .GetTypes()
        .Where(t => typeof(IShape).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
        .Select(t => typeof(ShapeButton<>).MakeGenericType(t))
        .ToArray();
}
```

Общий граф объектов после сборки контейнером содержит такие классы.
