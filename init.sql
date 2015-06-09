CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  password text,
  username text
);

CREATE TABLE tasks (
  id SERIAL PRIMARY KEY,
  userid integer REFERENCES users (id),
  title  text,
  description  text,
  creation date,
  status integer
);
