import { useAppSelector } from './useAppSelector';

export function useAuth() {
    return useAppSelector(state => state.authReducer);
}
