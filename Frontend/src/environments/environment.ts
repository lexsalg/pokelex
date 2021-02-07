
const domain = 'localhost:5000';
const version = 'v1';
const protocol = 'http';

export const environment = {
  production: false,
  api: `${protocol}://${domain}/api/${version}`
};

