// --- Статусы пользователя ---
const UserStatus = Object.freeze({
  ACTIVE: "ACTIVE",
  INACTIVE: "INACTIVE",
  BANNED: "BANNED",
});

// --- Модель пользователя ---
class Person {
  constructor(id, fullname, score, mail, state) {
    this.id = id;
    this.fullname = fullname;
    this.score = score;
    this.mail = mail;
    this.state = state;
  }

  // Удобный вывод
  toString(mask) {
    const data = [];
    if (hasField(mask, PersonFields.ID)) data.push(`ID: ${this.id}`);
    if (hasField(mask, PersonFields.NAME)) data.push(`Name: ${this.fullname}`);
    if (hasField(mask, PersonFields.SCORE)) data.push(`Score: ${this.score}`);
    if (hasField(mask, PersonFields.MAIL)) data.push(`Email: ${this.mail}`);
    if (hasField(mask, PersonFields.STATE)) data.push(`Status: ${this.state}`);
    return data.join(" | ");
  }
}

// --- Поля пользователя через битовые маски ---
const PersonFields = Object.freeze({
  ID: 1 << 0,       // 1
  NAME: 1 << 1,     // 2
  SCORE: 1 << 2,    // 4
  MAIL: 1 << 3,     // 8
  STATE: 1 << 4,    // 16
  ALL: (1 << 5) - 1 // 31
});

function hasField(mask, field) {
  return (mask & field) !== 0;
}

// --- "База данных" пользователей ---
class PersonRepository {
  constructor() {
    this._list = [];
  }

  insert(person) {
    this._list.push(person);
  }

  searchByName(name) {
    return this._list.filter(p => p.fullname === name);
  }

  static areEqualByMask(p1, p2, mask) {
    if (hasField(mask, PersonFields.ID) && p1.id !== p2.id) return false;
    if (hasField(mask, PersonFields.NAME) && p1.fullname !== p2.fullname) return false;
    if (hasField(mask, PersonFields.SCORE) && p1.score !== p2.score) return false;
    if (hasField(mask, PersonFields.MAIL) && p1.mail !== p2.mail) return false;
    if (hasField(mask, PersonFields.STATE) && p1.state !== p2.state) return false;
    return true;
  }

  // --- Слияние записей по маске ---
  collapseByMask(compareMask) {
    const compact = [];
    const visited = new Set();

    for (let i = 0; i < this._list.length; i++) {
      if (visited.has(i)) continue;
      const group = [this._list[i]];
      visited.add(i);

      for (let j = i + 1; j < this._list.length; j++) {
        if (visited.has(j)) continue;
        if (PersonRepository.areEqualByMask(this._list[i], this._list[j], compareMask)) {
          group.push(this._list[j]);
          visited.add(j);
        }
      }

      compact.push(group[0]); // оставляем первого
    }

    this._list = compact;
  }

  // --- Копирование полей ---
  propagateData(compareMask, updateMask, source) {
    for (const person of this._list) {
      if (PersonRepository.areEqualByMask(person, source, compareMask)) {
        if (hasField(updateMask, PersonFields.ID)) person.id = source.id;
        if (hasField(updateMask, PersonFields.NAME)) person.fullname = source.fullname;
        if (hasField(updateMask, PersonFields.SCORE)) person.score = source.score;
        if (hasField(updateMask, PersonFields.MAIL)) person.mail = source.mail;
        if (hasField(updateMask, PersonFields.STATE)) person.state = source.state;
      }
    }
  }

  // --- Печать всех пользователей ---
  printAll(mask = PersonFields.ALL) {
    this._list.forEach(p => console.log(p.toString(mask)));
  }
}

// --- Тестирование ---
const repo = new PersonRepository();

repo.insert(new Person(1, "Оливия", 4.5, "olivia@mail.com", UserStatus.ACTIVE));
repo.insert(new Person(2, "Сашка", 3.8, "sasha@mail.com", UserStatus.INACTIVE));
repo.insert(new Person(3, "Оливия", 4.9, "olivia2@mail.com", UserStatus.BANNED));
repo.insert(new Person(4, "Пашка", 5.0, "pashka@mail.com", UserStatus.BANNED));

console.log("== Исходные данные ==");
repo.printAll();

console.log("\n== Поиск по имени 'Оливия' ==");
repo.searchByName("Оливия").forEach(p =>
  console.log(p.toString(PersonFields.ID | PersonFields.NAME | PersonFields.SCORE | PersonFields.STATE))
);

console.log("\n== Слияние по имени + рейтингу ==");
repo.collapseByMask(PersonFields.NAME | PersonFields.SCORE);
repo.printAll();

console.log("\n== Обновление email для всех Оливий (по имени) ==");
const newSource = new Person(999, "Оливия", 0, "olivia@new.com", UserStatus.ACTIVE);
repo.propagateData(PersonFields.NAME, PersonFields.MAIL, newSource);
repo.printAll();
