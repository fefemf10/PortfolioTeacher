import { UserManager, WebStorageStateStore, UserManagerSettings, User } from 'oidc-client';
const oidcConfig:UserManagerSettings = {
  authority: `${window.location.origin}/id`,
  client_id: 'PortfolioSite',
  redirect_uri: `${window.location.origin}/authentication/login-callback`,
  post_logout_redirect_uri: `${window.location.origin}/authentication/logout-callback`,
  response_type: 'code',
  scope: 'openid profile PortfolioServer IdentityServerApi',
  userStore: new WebStorageStateStore({store: window.localStorage}),
  stateStore: new WebStorageStateStore({ store: window.sessionStorage }),
  silent_redirect_uri: `${window.location.origin}/authentication/silent-callback`,
  monitorSession:false,
  automaticSilentRenew: true,
  revokeAccessTokenOnSignout: true
};
const userManager = new UserManager(oidcConfig);
export const login = () => userManager.signinRedirect();
export const logout = () => userManager.signoutRedirect();
export const handleCallback = () => userManager.signinRedirectCallback();
export const guid = () => userManager.getUser().then(user => { return user?.profile?.sub });
export const isAuthenticated = () => userManager.getUser().then(user => { return !!user && !user.expired });
export default userManager;
