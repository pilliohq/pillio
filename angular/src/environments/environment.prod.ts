import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Pillio',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44321/',
    redirectUri: baseUrl,
    clientId: 'Pillio_App',
    responseType: 'code',
    scope: 'offline_access Pillio',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44325',
      rootNamespace: 'Pillio',
    },
  },
} as Environment;
