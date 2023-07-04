CREATE MIGRATION m1qeu4n4t3xv7tuhjnlj2tm3cuixdb6ci54p6bdmof6l57nt67ipqa
    ONTO initial
{
  CREATE TYPE default::Post {
      CREATE PROPERTY myOptionalArrayOfStrings: array<std::str>;
  };
};
