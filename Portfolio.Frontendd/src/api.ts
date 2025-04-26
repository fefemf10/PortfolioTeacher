import ky from 'ky';
import userManager from './oidc'

const api = ky.create({
  prefixUrl: `${window.location.origin}`,
  hooks: {
    beforeRequest: [
      async request => {
        const user = await userManager.getUser();
        const accessToken = user?.access_token;
        if (accessToken) {
          request.headers.set('Authorization', `Bearer ${accessToken}`);
        }
      }
    ]
  }
});

export default api;
